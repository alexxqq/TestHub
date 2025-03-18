﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestHub.DAL;

#nullable disable

namespace TestHub.DAL.Migrations
{
    [DbContext(typeof(TestingSystemContext))]
    [Migration("20250311071752_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestHub.DAL.Models.Answer", b =>
                {
                    b.Property<int>("answer_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("answer_id"));

                    b.Property<string>("answer_text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("is_correct")
                        .HasColumnType("boolean");

                    b.Property<int>("question_id")
                        .HasColumnType("integer");

                    b.HasKey("answer_id");

                    b.ToTable("answers");
                });

            modelBuilder.Entity("TestHub.DAL.Models.Class", b =>
                {
                    b.Property<int>("class_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("class_id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("user_id")
                        .HasColumnType("integer");

                    b.HasKey("class_id");

                    b.ToTable("classes");
                });

            modelBuilder.Entity("TestHub.DAL.Models.Member", b =>
                {
                    b.Property<int>("member_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("member_id"));

                    b.Property<int>("class_id")
                        .HasColumnType("integer");

                    b.Property<int>("user_id")
                        .HasColumnType("integer");

                    b.HasKey("member_id");

                    b.ToTable("members");
                });

            modelBuilder.Entity("TestHub.DAL.Models.Message", b =>
                {
                    b.Property<int>("message_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("message_id"));

                    b.Property<int>("class_id")
                        .HasColumnType("integer");

                    b.Property<string>("content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("recipient_id")
                        .HasColumnType("integer");

                    b.Property<int>("sender_id")
                        .HasColumnType("integer");

                    b.Property<DateTime>("sent_at")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("message_id");

                    b.ToTable("messages");
                });

            modelBuilder.Entity("TestHub.DAL.Models.Question", b =>
                {
                    b.Property<int>("question_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("question_id"));

                    b.Property<string>("question_text")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("question_type")
                        .HasColumnType("integer");

                    b.Property<int>("test_id")
                        .HasColumnType("integer");

                    b.HasKey("question_id");

                    b.ToTable("questions");
                });

            modelBuilder.Entity("TestHub.DAL.Models.Result", b =>
                {
                    b.Property<int>("result_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("result_id"));

                    b.Property<int>("attempt_number")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("completed_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal?>("score")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("start_time")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("test_id")
                        .HasColumnType("integer");

                    b.Property<int>("user_id")
                        .HasColumnType("integer");

                    b.Property<string>("user_report")
                        .HasColumnType("text");

                    b.HasKey("result_id");

                    b.ToTable("results");
                });

            modelBuilder.Entity("TestHub.DAL.Models.StatusChange", b =>
                {
                    b.Property<int>("status_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("status_id"));

                    b.Property<DateTime>("changed_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("new_status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("old_status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("test_id")
                        .HasColumnType("integer");

                    b.Property<int>("user_id")
                        .HasColumnType("integer");

                    b.HasKey("status_id");

                    b.ToTable("status_changes");
                });

            modelBuilder.Entity("TestHub.DAL.Models.Test", b =>
                {
                    b.Property<int>("test_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("test_id"));

                    b.Property<string>("area")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("available_from")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("available_to")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("class_id")
                        .HasColumnType("integer");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("duration")
                        .HasColumnType("integer");

                    b.Property<int>("max_attempts")
                        .HasColumnType("integer");

                    b.Property<int>("status")
                        .HasColumnType("integer");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("user_id")
                        .HasColumnType("integer");

                    b.Property<int>("visibility")
                        .HasColumnType("integer");

                    b.HasKey("test_id");

                    b.ToTable("tests");
                });

            modelBuilder.Entity("TestHub.DAL.Models.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("user_id"));

                    b.Property<DateTime>("created_at")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password_hash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("user_id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
