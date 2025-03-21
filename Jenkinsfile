pipeline {
    agent any

    environment {
        IMAGE_NAME = credentials('IMAGE_NAME')
        CONTAINER_NAME = credentials('CONTAINER_NAME')
        AWS_DEV_EC2_IP = credentials('AWS_DEV_EC2_IP')
        AWS_PROD_EC2_IP = credentials('AWS_PROD_EC2_IP')

        DB_HOST = credentials('DB_HOST')
        DB_PASS = credentials('DB_PASS')
        DB_PORT = credentials('DB_PORT')
        DB_NAME = credentials('DB_NAME')
        DB_USER = credentials('DB_USER')

        BRANCH_NAME = "${GIT_BRANCH.split("/")[1]}"
    }

    stages {
        stage('Checkout Code') {
            steps {
                git branch: BRANCH_NAME, url: 'https://github.com/alexxqq/TestHub.git'
            }
        }

        stage('Build Docker Image') {
            steps {
                sh 'docker build -t $IMAGE_NAME -f Dockerfile .'
            }
        }

        stage('Push Image to AWS EC2') {
            steps {
                script {
                    def server_ip = (env.BRANCH_NAME == 'develop') ? env.AWS_DEV_EC2_IP : env.AWS_PROD_EC2_IP
                    echo "Pushing image to: ${server_ip}"
                    sshagent(['jenkins-aws-key']) {
                        sh """
                            docker save $IMAGE_NAME | bzip2 | ssh -o StrictHostKeyChecking=no ubuntu@${server_ip} 'bunzip2 | docker load'
                        """
                    }
                }
            }
        }

        stage('Deploy to AWS EC2') {
            steps {
                script {
                    def server_ip = (BRANCH_NAME == 'develop') ? AWS_DEV_EC2_IP : AWS_PROD_EC2_IP
                    sshagent(['jenkins-aws-key']) {
                        sh """
                            ssh -o StrictHostKeyChecking=no ubuntu@${server_ip} "
                            docker kill $CONTAINER_NAME || true &&
                            docker rm $CONTAINER_NAME || true &&
                            docker images --format '{{.Repository}}:{{.Tag}}' | grep $IMAGE_NAME | grep -v 'latest' | xargs -r docker rmi || true &&
                            docker run -d -p 8080:8080 --env DB_HOST=$DB_HOST --env DB_PASS=$DB_PASS --env DB_PORT=$DB_PORT --env DB_NAME=$DB_NAME --env DB_USER=$DB_USER --name $CONTAINER_NAME $IMAGE_NAME
                            docker system prune --all --force
                            "
                        """
                    }
                }
            }
        }

    }
}
