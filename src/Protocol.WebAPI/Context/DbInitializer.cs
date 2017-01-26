using Protocol.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Protocol.WebAPI.Context
{
    public class DbInitializer
    {
        public static void Initializer(ProtocolDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Documents.Any())
            {
                return;
            }

            var authAgr1 = new AuthorityAgreement { Name = "Министстерство финансов Республики Карелия" };
            var authAgr2 = new AuthorityAgreement { Name = "Прокуратура Республики Карелия" };
            var authAgr3 = new AuthorityAgreement { Name = "Контрольный комитет Республики Карелия" };
            var authAgr4 = new AuthorityAgreement { Name = "Министрерство экономического развития Республики Карелия" };
            var authAgr5 = new AuthorityAgreement { Name = "Администрация Главы Республики Карелия" };

            var authAgrs = new List<AuthorityAgreement>();
            authAgrs.Add(authAgr1);
            authAgrs.Add(authAgr2);
            authAgrs.Add(authAgr3);
            authAgrs.Add(authAgr4);
            authAgrs.Add(authAgr5);

            context.AuthorityAgreements.AddRange(authAgrs);
            context.SaveChanges();

            var docType1 = new DocumentType { Name = "Указ Главы Республики Карелия" };
            var docType2 = new DocumentType { Name = "Распоряжение Главы Республики Карелия" };
            var docType3 = new DocumentType { Name = "Постановление Правительства Республики Карелия" };
            var docType4 = new DocumentType { Name = "Решения Правительства Республики Карелия" };

            var docTypes = new List<DocumentType>();
            docTypes.Add(docType1);
            docTypes.Add(docType2);
            docTypes.Add(docType3);
            docTypes.Add(docType4);

            context.DocumentTypes.AddRange(docTypes);
            context.SaveChanges();

            var sender1 = new Sender { Name = "Министерство труда и занятости Республики Карелия" };
            var sender2 = new Sender { Name = "Министерство экономического развития Республики Карелия" };
            var sender3 = new Sender { Name = "Министерство финансов Республики Карелия" };
            var sender4 = new Sender { Name = "Министерство строительства Республики Карелия" };

            context.Senders.Add(sender1);
            context.Senders.Add(sender2);
            context.SaveChanges();

            var doc1 = new Document
            {
                RegistrationDate = new DateTime(2016, 12, 8),
                ProjectNumber = "14-1",
                DocumentType = docType1,
                ContactName = "Петров П.П.",
                ContactPhone = "736-585",
                Sender = sender1,
                ProjectDescription = "Важная информация 1",
                Agreements = new List<Agreement>
                {
                    new Agreement { AuthorityAgreement = authAgr2, Date = new DateTime(2016, 12, 8), ReturnDate = new DateTime(2016, 12, 12), AgreementSignature = "Федоров И.И." },
                    new Agreement { AuthorityAgreement = authAgr3, Date = new DateTime(2016, 12, 13), ReturnDate = new DateTime(2016, 12, 17), AgreementSignature = "Петров С.С." },
                    new Agreement { AuthorityAgreement = authAgr4, Date = new DateTime(2016, 12, 18), ReturnDate = new DateTime(2016, 12, 21), AgreementSignature = "Сидоренко П.С." },
                    new Agreement { AuthorityAgreement = authAgr5, Date = new DateTime(2016, 12, 22), ReturnDate = new DateTime(2016, 12, 25), AgreementSignature = "Зайцев В.Д." }
                },
                PublicationDate = new DateTime(2016, 12, 26),
                PublicationNumber = "78",
                PublicationSignature = "Клименко С.И.",
                IsProject = false,
                IsApproved = false
                
            };

            var doc2 = new Document
            {
                RegistrationDate = new DateTime(2016, 11, 21),
                ProjectNumber = "14-2",
                DocumentType = docType3,
                ContactName = "Иванов И.И.",
                ContactPhone = "799-267",
                Sender = sender2,
                ProjectDescription = "Важная информация 2",
                IsApproved = true,
                Agreements = new List<Agreement>
                {
                    new Agreement { AuthorityAgreement = authAgr1, Date = new DateTime(2016, 11, 21), ReturnDate = new DateTime(2016, 11, 25), AgreementSignature = "Васечкин В.В." },
                    new Agreement { AuthorityAgreement = authAgr2, Date = new DateTime(2016, 11, 26), ReturnDate = new DateTime(2016, 11, 29), AgreementSignature = "Федоров И.И." },
                    new Agreement { AuthorityAgreement = authAgr3, Date = new DateTime(2016, 11, 30), ReturnDate = new DateTime(2016, 12, 4), AgreementSignature = "Петров С.С." }
                }
            };

            var doc3 = new Document
            {
                RegistrationDate = new DateTime(2016, 10, 1),
                ProjectNumber = "14-3",
                DocumentType = docType4,
                ContactName = "Иванов И.И.",
                ContactPhone = "799-267",
                Sender = sender2,
                ProjectDescription = "Важная информация 3",
                IsApproved = true,
                Agreements = new List<Agreement>
                {
                    new Agreement { AuthorityAgreement = authAgr1, Date = new DateTime(2016, 10, 1), ReturnDate = new DateTime(2016, 10, 4), AgreementSignature = "Васечкин В.В." },
                    new Agreement { AuthorityAgreement = authAgr2, Date = new DateTime(2016, 10, 5), ReturnDate = new DateTime(2016, 10, 9), AgreementSignature = "Федоров И.И." },
                    new Agreement { AuthorityAgreement = authAgr3, Date = new DateTime(2016, 10, 10), ReturnDate = new DateTime(2016, 10, 15), AgreementSignature = "Петров С.С." }
                }
            };

            var doc4 = new Document
            {
                RegistrationDate = new DateTime(2016, 12, 11),
                ProjectNumber = "14-4",
                DocumentType = docType1,
                ContactName = "Иванов И.И.",
                ContactPhone = "799-267",
                Sender = sender2,
                ProjectDescription = "Важная информация 4"                
            };

            var doc5 = new Document
            {
                RegistrationDate = new DateTime(2017, 01, 8),
                ProjectNumber = "14-5",
                DocumentType = docType2,
                ContactName = "Сидоров С.П.",
                ContactPhone = "736-245",
                Sender = sender3,
                ProjectDescription = "Важная информация 1",
                Agreements = new List<Agreement>
                {
                    new Agreement { AuthorityAgreement = authAgr2, Date = new DateTime(2016, 12, 8), ReturnDate = new DateTime(2016, 12, 12), AgreementSignature = "Федоров И.И." },
                    new Agreement { AuthorityAgreement = authAgr3, Date = new DateTime(2016, 12, 13), ReturnDate = new DateTime(2016, 12, 17), AgreementSignature = "Петров С.С." },
                    new Agreement { AuthorityAgreement = authAgr4, Date = new DateTime(2016, 12, 18), ReturnDate = new DateTime(2016, 12, 21), AgreementSignature = "Сидоренко П.С." },
                    new Agreement { AuthorityAgreement = authAgr5, Date = new DateTime(2016, 12, 22), ReturnDate = new DateTime(2016, 12, 25), AgreementSignature = "Зайцев В.Д." }
                },
                PublicationDate = new DateTime(2017, 01, 14),
                PublicationNumber = "125-П",
                PublicationSignature = "Клименко С.И.",
                IsProject = false,
                IsApproved = false

            };

            var doc6 = new Document
            {
                RegistrationDate = new DateTime(2016, 12, 24),
                ProjectNumber = "14-6",
                DocumentType = docType3,
                ContactName = "Захаров И.В.",
                ContactPhone = "736-156",
                Sender = sender4,
                ProjectDescription = "Важная информация 1",
                Agreements = new List<Agreement>
                {
                    new Agreement { AuthorityAgreement = authAgr2, Date = new DateTime(2016, 12, 8), ReturnDate = new DateTime(2016, 12, 12), AgreementSignature = "Федоров И.И." },
                    new Agreement { AuthorityAgreement = authAgr3, Date = new DateTime(2016, 12, 13), ReturnDate = new DateTime(2016, 12, 17), AgreementSignature = "Петров С.С." },
                    new Agreement { AuthorityAgreement = authAgr4, Date = new DateTime(2016, 12, 18), ReturnDate = new DateTime(2016, 12, 21), AgreementSignature = "Сидоренко П.С." },
                    new Agreement { AuthorityAgreement = authAgr5, Date = new DateTime(2016, 12, 22), ReturnDate = new DateTime(2016, 12, 25), AgreementSignature = "Зайцев В.Д." }
                },
                PublicationDate = new DateTime(2016, 12, 28),
                PublicationNumber = "30-Пр",
                PublicationSignature = "Клименко С.И.",
                IsProject = false,
                IsApproved = false

            };

            var doc7 = new Document
            {
                RegistrationDate = new DateTime(2016, 10, 15),
                ProjectNumber = "14-1",
                DocumentType = docType1,
                ContactName = "Петров П.П.",
                ContactPhone = "736-585",
                Sender = sender1,
                ProjectDescription = "Важная информация 1",
                Agreements = new List<Agreement>
                {
                    new Agreement { AuthorityAgreement = authAgr2, Date = new DateTime(2016, 12, 8), ReturnDate = new DateTime(2016, 12, 12), AgreementSignature = "Федоров И.И." },
                    new Agreement { AuthorityAgreement = authAgr3, Date = new DateTime(2016, 12, 13), ReturnDate = new DateTime(2016, 12, 17), AgreementSignature = "Петров С.С." },
                    new Agreement { AuthorityAgreement = authAgr4, Date = new DateTime(2016, 12, 18), ReturnDate = new DateTime(2016, 12, 21), AgreementSignature = "Сидоренко П.С." },
                    new Agreement { AuthorityAgreement = authAgr5, Date = new DateTime(2016, 12, 22), ReturnDate = new DateTime(2016, 12, 25), AgreementSignature = "Зайцев В.Д." }
                }
            };

            context.Documents.Add(doc1);
            context.Documents.Add(doc2);
            context.Documents.Add(doc3);
            context.Documents.Add(doc4);
            context.Documents.Add(doc5);
            context.Documents.Add(doc6);
            context.Documents.Add(doc7);
            context.SaveChanges();
        }
    }
}
