﻿// <auto-generated />
using System;
using LBPUnion.ProjectLighthouse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ProjectLighthouse.Migrations
{
    [DbContext(typeof(Database))]
    partial class DatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.Administration.CompletedMigration", b =>
                {
                    b.Property<string>("MigrationName")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("RanAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("MigrationName");

                    b.ToTable("CompletedMigrations");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.Administration.Reports.GriefReport", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bounds")
                        .HasColumnType("longtext");

                    b.Property<string>("GriefStateHash")
                        .HasColumnType("longtext");

                    b.Property<string>("InitialStateHash")
                        .HasColumnType("longtext");

                    b.Property<string>("JpegHash")
                        .HasColumnType("longtext");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("LevelOwner")
                        .HasColumnType("longtext");

                    b.Property<string>("LevelType")
                        .HasColumnType("longtext");

                    b.Property<string>("Players")
                        .HasColumnType("longtext");

                    b.Property<int>("ReportingPlayerId")
                        .HasColumnType("int");

                    b.Property<long>("Timestamp")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ReportId");

                    b.HasIndex("ReportingPlayerId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.Levels.Categories.DatabaseCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Endpoint")
                        .HasColumnType("longtext");

                    b.Property<string>("IconHash")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("SlotIdsCollection")
                        .HasColumnType("longtext");

                    b.HasKey("CategoryId");

                    b.ToTable("CustomCategories");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.Levels.HeartedLevel", b =>
                {
                    b.Property<int>("HeartedLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("SlotId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("HeartedLevelId");

                    b.HasIndex("SlotId");

                    b.HasIndex("UserId");

                    b.ToTable("HeartedLevels");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.Levels.QueuedLevel", b =>
                {
                    b.Property<int>("QueuedLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("SlotId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("QueuedLevelId");

                    b.HasIndex("SlotId");

                    b.HasIndex("UserId");

                    b.ToTable("QueuedLevels");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.Levels.RatedLevel", b =>
                {
                    b.Property<int>("RatedLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<double>("RatingLBP1")
                        .HasColumnType("double");

                    b.Property<int>("SlotId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RatedLevelId");

                    b.HasIndex("SlotId");

                    b.HasIndex("UserId");

                    b.ToTable("RatedLevels");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.Levels.Slot", b =>
                {
                    b.Property<int>("SlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AuthorLabels")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("BackgroundHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<bool>("CrossControllerRequired")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("FirstUploaded")
                        .HasColumnType("bigint");

                    b.Property<int>("GameVersion")
                        .HasColumnType("int");

                    b.Property<string>("IconHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("InitiallyLocked")
                        .HasColumnType("tinyint(1)");

                    b.Property<long>("LastUpdated")
                        .HasColumnType("bigint");

                    b.Property<bool>("Lbp1Only")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LevelType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("MaximumPlayers")
                        .HasColumnType("int");

                    b.Property<int>("MinimumPlayers")
                        .HasColumnType("int");

                    b.Property<bool>("MoveRequired")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PlaysLBP1")
                        .HasColumnType("int");

                    b.Property<int>("PlaysLBP1Complete")
                        .HasColumnType("int");

                    b.Property<int>("PlaysLBP1Unique")
                        .HasColumnType("int");

                    b.Property<int>("PlaysLBP2")
                        .HasColumnType("int");

                    b.Property<int>("PlaysLBP2Complete")
                        .HasColumnType("int");

                    b.Property<int>("PlaysLBP2Unique")
                        .HasColumnType("int");

                    b.Property<int>("PlaysLBP3")
                        .HasColumnType("int");

                    b.Property<int>("PlaysLBP3Complete")
                        .HasColumnType("int");

                    b.Property<int>("PlaysLBP3Unique")
                        .HasColumnType("int");

                    b.Property<int>("PlaysLBPVita")
                        .HasColumnType("int");

                    b.Property<int>("PlaysLBPVitaComplete")
                        .HasColumnType("int");

                    b.Property<int>("PlaysLBPVitaUnique")
                        .HasColumnType("int");

                    b.Property<string>("ResourceCollection")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RootLevel")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Shareable")
                        .HasColumnType("int");

                    b.Property<bool>("SubLevel")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("TeamPick")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("SlotId");

                    b.HasIndex("CreatorId");

                    b.HasIndex("LocationId");

                    b.ToTable("Slots");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.Levels.VisitedLevel", b =>
                {
                    b.Property<int>("VisitedLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PlaysLBP1")
                        .HasColumnType("int");

                    b.Property<int>("PlaysLBP2")
                        .HasColumnType("int");

                    b.Property<int>("PlaysLBP3")
                        .HasColumnType("int");

                    b.Property<int>("PlaysLBPVita")
                        .HasColumnType("int");

                    b.Property<int>("SlotId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("VisitedLevelId");

                    b.HasIndex("SlotId");

                    b.HasIndex("UserId");

                    b.ToTable("VisitedLevels");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.APIKey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<bool>("Enabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Key")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("APIKeys");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.AuthenticationAttempt", b =>
                {
                    b.Property<int>("AuthenticationAttemptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("GameTokenId")
                        .HasColumnType("int");

                    b.Property<string>("IPAddress")
                        .HasColumnType("longtext");

                    b.Property<int>("Platform")
                        .HasColumnType("int");

                    b.Property<long>("Timestamp")
                        .HasColumnType("bigint");

                    b.HasKey("AuthenticationAttemptId");

                    b.HasIndex("GameTokenId");

                    b.ToTable("AuthenticationAttempts");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.GameToken", b =>
                {
                    b.Property<int>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Approved")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("GameVersion")
                        .HasColumnType("int");

                    b.Property<int>("Platform")
                        .HasColumnType("int");

                    b.Property<bool>("Used")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserLocation")
                        .HasColumnType("longtext");

                    b.Property<string>("UserToken")
                        .HasColumnType("longtext");

                    b.HasKey("TokenId");

                    b.HasIndex("UserId");

                    b.ToTable("GameTokens");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.PasswordResetToken", b =>
                {
                    b.Property<int>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ResetToken")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TokenId");

                    b.ToTable("PasswordResetTokens");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("LargeHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MediumHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhotoSubjectCollection")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PlanHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SmallHash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("Timestamp")
                        .HasColumnType("bigint");

                    b.HasKey("PhotoId");

                    b.HasIndex("CreatorId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.PhotoSubject", b =>
                {
                    b.Property<int>("PhotoSubjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bounds")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PhotoSubjectId");

                    b.HasIndex("UserId");

                    b.ToTable("PhotoSubjects");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Profiles.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("DeletedBy")
                        .HasColumnType("longtext");

                    b.Property<string>("DeletedType")
                        .HasColumnType("longtext");

                    b.Property<string>("Message")
                        .HasColumnType("longtext");

                    b.Property<int>("PosterUserId")
                        .HasColumnType("int");

                    b.Property<int>("TargetId")
                        .HasColumnType("int");

                    b.Property<int>("ThumbsDown")
                        .HasColumnType("int");

                    b.Property<int>("ThumbsUp")
                        .HasColumnType("int");

                    b.Property<long>("Timestamp")
                        .HasColumnType("bigint");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("CommentId");

                    b.HasIndex("PosterUserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Profiles.Email.EmailSetToken", b =>
                {
                    b.Property<int>("EmailSetTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EmailToken")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EmailSetTokenId");

                    b.HasIndex("UserId");

                    b.ToTable("EmailSetTokens");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Profiles.Email.EmailVerificationToken", b =>
                {
                    b.Property<int>("EmailVerificationTokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("EmailToken")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("EmailVerificationTokenId");

                    b.HasIndex("UserId");

                    b.ToTable("EmailVerificationTokens");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Profiles.HeartedProfile", b =>
                {
                    b.Property<int>("HeartedProfileId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("HeartedUserId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("HeartedProfileId");

                    b.HasIndex("HeartedUserId");

                    b.HasIndex("UserId");

                    b.ToTable("HeartedProfiles");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Profiles.LastContact", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("GameVersion")
                        .HasColumnType("int");

                    b.Property<int>("Platform")
                        .HasColumnType("int");

                    b.Property<long>("Timestamp")
                        .HasColumnType("bigint");

                    b.HasKey("UserId");

                    b.ToTable("LastContacts");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Profiles.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("X")
                        .HasColumnType("int");

                    b.Property<int>("Y")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AdminGrantedSlots")
                        .HasColumnType("int");

                    b.Property<string>("ApprovedIPAddress")
                        .HasColumnType("longtext");

                    b.Property<bool>("Banned")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("BannedReason")
                        .HasColumnType("longtext");

                    b.Property<string>("Biography")
                        .HasColumnType("longtext");

                    b.Property<string>("BooHash")
                        .HasColumnType("longtext");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailAddressVerified")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Game")
                        .HasColumnType("int");

                    b.Property<string>("IconHash")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("MehHash")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<bool>("PasswordResetRequired")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Pins")
                        .HasColumnType("longtext");

                    b.Property<string>("PlanetHashLBP2")
                        .HasColumnType("longtext");

                    b.Property<string>("PlanetHashLBP3")
                        .HasColumnType("longtext");

                    b.Property<string>("PlanetHashLBPVita")
                        .HasColumnType("longtext");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.Property<string>("YayHash")
                        .HasColumnType("longtext");

                    b.HasKey("UserId");

                    b.HasIndex("LocationId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Reaction", b =>
                {
                    b.Property<int>("RatingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("TargetId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RatingId");

                    b.ToTable("Reactions");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.RegistrationToken", b =>
                {
                    b.Property<int>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext");

                    b.HasKey("TokenId");

                    b.ToTable("RegistrationTokens");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Reviews.RatedReview", b =>
                {
                    b.Property<int>("RatedReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ReviewId")
                        .HasColumnType("int");

                    b.Property<int>("Thumb")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("RatedReviewId");

                    b.HasIndex("ReviewId");

                    b.HasIndex("UserId");

                    b.ToTable("RatedReviews");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Reviews.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("DeletedBy")
                        .HasColumnType("int");

                    b.Property<string>("LabelCollection")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ReviewerId")
                        .HasColumnType("int");

                    b.Property<int>("SlotId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Thumb")
                        .HasColumnType("int");

                    b.Property<int>("ThumbsDown")
                        .HasColumnType("int");

                    b.Property<int>("ThumbsUp")
                        .HasColumnType("int");

                    b.Property<long>("Timestamp")
                        .HasColumnType("bigint");

                    b.HasKey("ReviewId");

                    b.HasIndex("ReviewerId");

                    b.HasIndex("SlotId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Score", b =>
                {
                    b.Property<int>("ScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PlayerIdCollection")
                        .HasColumnType("longtext");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("SlotId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ScoreId");

                    b.HasIndex("SlotId");

                    b.ToTable("Scores");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.WebToken", b =>
                {
                    b.Property<int>("TokenId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserToken")
                        .HasColumnType("longtext");

                    b.HasKey("TokenId");

                    b.ToTable("WebTokens");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.Administration.Reports.GriefReport", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "ReportingPlayer")
                        .WithMany()
                        .HasForeignKey("ReportingPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ReportingPlayer");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.Levels.HeartedLevel", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.Levels.Slot", "Slot")
                        .WithMany()
                        .HasForeignKey("SlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Slot");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.Levels.QueuedLevel", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.Levels.Slot", "Slot")
                        .WithMany()
                        .HasForeignKey("SlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Slot");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.Levels.RatedLevel", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.Levels.Slot", "Slot")
                        .WithMany()
                        .HasForeignKey("SlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Slot");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.Levels.Slot", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");

                    b.Navigation("Location");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.Levels.VisitedLevel", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.Levels.Slot", "Slot")
                        .WithMany()
                        .HasForeignKey("SlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Slot");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.AuthenticationAttempt", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.GameToken", "GameToken")
                        .WithMany()
                        .HasForeignKey("GameTokenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameToken");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.GameToken", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Photo", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.PhotoSubject", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Profiles.Comment", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "Poster")
                        .WithMany()
                        .HasForeignKey("PosterUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poster");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Profiles.Email.EmailSetToken", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Profiles.Email.EmailVerificationToken", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Profiles.HeartedProfile", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "HeartedUser")
                        .WithMany()
                        .HasForeignKey("HeartedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HeartedUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Profiles.LastContact", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Reviews.RatedReview", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Reviews.Review", "Review")
                        .WithMany()
                        .HasForeignKey("ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Review");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Reviews.Review", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.PlayerData.Profiles.User", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LBPUnion.ProjectLighthouse.Levels.Slot", "Slot")
                        .WithMany()
                        .HasForeignKey("SlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reviewer");

                    b.Navigation("Slot");
                });

            modelBuilder.Entity("LBPUnion.ProjectLighthouse.PlayerData.Score", b =>
                {
                    b.HasOne("LBPUnion.ProjectLighthouse.Levels.Slot", "Slot")
                        .WithMany()
                        .HasForeignKey("SlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Slot");
                });
#pragma warning restore 612, 618
        }
    }
}
