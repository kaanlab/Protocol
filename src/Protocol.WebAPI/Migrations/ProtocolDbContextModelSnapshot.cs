using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Protocol.WebAPI.Context;

namespace Protocol.WebAPI.Migrations
{
    [DbContext(typeof(ProtocolDbContext))]
    partial class ProtocolDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Protocol.WebAPI.Models.Agreement", b =>
                {
                    b.Property<int>("AgreementId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AgreementSignature");

                    b.Property<int?>("AuthorityAgreementId");

                    b.Property<DateTime>("Date");

                    b.Property<int?>("DocumentId");

                    b.Property<DateTime>("ReturnDate");

                    b.HasKey("AgreementId");

                    b.HasIndex("AuthorityAgreementId");

                    b.HasIndex("DocumentId");

                    b.ToTable("Agreements");
                });

            modelBuilder.Entity("Protocol.WebAPI.Models.AuthorityAgreement", b =>
                {
                    b.Property<int>("AuthorityAgreementId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("AuthorityAgreementId");

                    b.ToTable("AuthorityAgreements");
                });

            modelBuilder.Entity("Protocol.WebAPI.Models.Document", b =>
                {
                    b.Property<int>("DocumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ContactName");

                    b.Property<string>("ContactPhone");

                    b.Property<string>("DocFile");

                    b.Property<int>("DocumentTypeId");

                    b.Property<string>("IncomingDocNumber");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsProject");

                    b.Property<string>("PdfFile");

                    b.Property<string>("ProjectDescription");

                    b.Property<string>("ProjectNumber");

                    b.Property<DateTime?>("PublicationDate");

                    b.Property<string>("PublicationNumber");

                    b.Property<string>("PublicationSignature");

                    b.Property<DateTime>("RegistrationDate");

                    b.Property<int>("SenderId");

                    b.HasKey("DocumentId");

                    b.HasIndex("DocumentTypeId");

                    b.HasIndex("SenderId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Protocol.WebAPI.Models.DocumentType", b =>
                {
                    b.Property<int>("DocumentTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("DocumentTypeId");

                    b.ToTable("DocumentTypes");
                });

            modelBuilder.Entity("Protocol.WebAPI.Models.Sender", b =>
                {
                    b.Property<int>("SenderId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("SenderId");

                    b.ToTable("Senders");
                });

            modelBuilder.Entity("Protocol.WebAPI.Models.Agreement", b =>
                {
                    b.HasOne("Protocol.WebAPI.Models.AuthorityAgreement", "AuthorityAgreement")
                        .WithMany()
                        .HasForeignKey("AuthorityAgreementId");

                    b.HasOne("Protocol.WebAPI.Models.Document")
                        .WithMany("Agreements")
                        .HasForeignKey("DocumentId");
                });

            modelBuilder.Entity("Protocol.WebAPI.Models.Document", b =>
                {
                    b.HasOne("Protocol.WebAPI.Models.DocumentType", "DocumentType")
                        .WithMany()
                        .HasForeignKey("DocumentTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Protocol.WebAPI.Models.Sender", "Sender")
                        .WithMany()
                        .HasForeignKey("SenderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
