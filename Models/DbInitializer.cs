using InaBeauty;
using InaBeauty.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Salon.Models
{
    public class DbInitializer
    {
        public static void Initialize(SalonContext context)
        {
            //context.Database.EnsureCreated();

            // Verificam daca exista clienti
            if (context.Clienti.Any())
            {
                return;   // DB has been seeded
            }
            var clienti = new Client[]
            {
                new Client{Nume="Popa",Prenume="Ioana",DataProgramare=DateTime.Parse("21-07-2020")},
                new Client{Nume="Marin",Prenume="Elena",DataProgramare=DateTime.Parse("08-11.2020")},
                new Client{Nume="Guias",Prenume="Daniela",DataProgramare=DateTime.Parse("01-02-2021")},
                new Client{Nume="Branza",Prenume="Maria",DataProgramare=DateTime.Parse("19-07-2020")},
                new Client{Nume="Cosma",Prenume="Vladuta",DataProgramare=DateTime.Parse("25-06-2020")},
                new Client{Nume="Lungu",Prenume="Carmen",DataProgramare=DateTime.Parse("18-02-2020")},
                new Client{Nume="Florian",Prenume="Ana",DataProgramare=DateTime.Parse("20-01-2021")},
                new Client{Nume="Tocaci",Prenume="Mirela",DataProgramare=DateTime.Parse("24-05-2021")}

            };
            foreach (Client c in clienti)
            {
                context.Clienti.Add(c);
            }
            context.SaveChanges();
            var membrii = new Membru[]
            {
                new Membru{Nume="Stejeran", Prenume="Natalia", DataAngajare=DateTime.Parse("04-05-2016")},
                new Membru{Nume="Crainic", Prenume="Alexandra", DataAngajare=DateTime.Parse("22-06-2015")},
                new Membru{Nume="Stejeran", Prenume="Ancuta", DataAngajare=DateTime.Parse("17-08-2017")},
                new Membru{Nume="Gherghiceanu", Prenume="Ana", DataAngajare=DateTime.Parse("17-05-2014")},
                new Membru{Nume="Florica", Prenume="Ilies", DataAngajare=DateTime.Parse("17-05-2014")},

            };
            foreach (Membru m in membrii)
            {
                context.Membrii.Add(m);
            }
            context.SaveChanges();

            var servicii = new Serviciu[]
            {
                new Serviciu{ServiciuID=10,Denumire="Tuns par lung",Descriere="Pentru mentine firul de par capilar, sanatos, periodic acesta trebuie a fi scurtat, pentru a preveni despicarea lui si astfel acesta va arata mult mai frumos si cu o tinuta de invidiat.",Durata=45,Pret=70},
                new Serviciu{ServiciuID=20,Denumire="Tuns par scurt",Descriere="Pentru mentine firul de par capilar, sanatos, periodic acesta trebuie a fi scurtat, pentru a preveni despicarea lui si astfel acesta va arata mult mai frumos si cu o tinuta de invidiat.",Durata=15,Pret=50},
                new Serviciu{ServiciuID=30,Denumire="Aplicare gene",Descriere="Se spune că ochii sunt oglinda sufletului. Noi doar îi vom pune mai mult în valoare.",Durata=30,Pret=80},
                new Serviciu{ServiciuID=40,Denumire="Terapia cu pietre calde",Descriere="Este unul dintre cele mai potrivite remedii pentru relexare, stari de stres, anxietate, probleme ale spatelui, dureri musculare si probleme circulatorii. Aceasta terapie echilibreaza nivelul energetic si reintinereste pielea",Durata=60,Pret=150},
                new Serviciu{ServiciuID=50,Denumire="Mani/Pedi",Descriere="Pentru o mai buna si profesional ingrijire a piciorului si sanatatii unghiei, apelam la serviciile specialistei. Pe langa relaxarea pe care o vom avea, vom beneficia si de o pedichiura curata si frumoasa.",Durata=45,Pret=100},
                new Serviciu{ServiciuID=60,Denumire="Machiaj",Descriere="Pentru fiecare eveniment ne pregatim cum putem mai bine. Deloc de neglijat este modul in care ne prezentam . Pentru a pune in valoare frumusetea noastra, un machiaj profesional este cea mai buna solutie.",Durata=45,Pret=80},
                new Serviciu{ServiciuID=70,Denumire="Pensat",Descriere="Pentru a pune mai mult in valoare frumusetea ochilor, forma sprancenelor este foarte importanta. Aici intervenim noi, pentru a echilibra forma sprancenelor si a da o nota de eleganta intregii fizionomii.",Durata=15,Pret=20},
                new Serviciu{ServiciuID=80,Denumire="Vopsit",Descriere="Fie ca ne dorim sa ascundem firele carunte, fie ca dorim sa improspatam culoarea parului nostru, sau pur si simplu, vrem sa fim mai indraznete, alegem o culoare care ne va da acel aspect unic.",Durata=75,Pret=120},
            };
            foreach (Serviciu s in servicii)
            {
                context.Servicii.Add(s);
            }
            context.SaveChanges();

            var membriiServicii = new AlocareServiciu[]
            {
                new AlocareServiciu
                {
                    ServiciuID=servicii.Single(c=>c.Denumire=="Tuns par lung").ServiciuID,
                    MembruID=membrii.Single(m=>m.Nume=="Florica").Id
                },
                new AlocareServiciu
                {
                    ServiciuID=servicii.Single(c=>c.Denumire=="Tuns par lung").ServiciuID,
                    MembruID=membrii.Single(m=>m.Nume=="Crainic").Id
                },
                new AlocareServiciu
                {
                    ServiciuID=servicii.Single(c=>c.Denumire=="Tuns par scurt").ServiciuID,
                    MembruID=membrii.Single(m=>m.Nume=="Florica").Id
                },
                new AlocareServiciu
                {
                    ServiciuID=servicii.Single(c=>c.Denumire=="Aplicare gene").ServiciuID,
                    MembruID=membrii.Single(m=>m.Nume=="Gherghiceanu").Id
                },
                new AlocareServiciu
                {
                    ServiciuID=servicii.Single(c=>c.Denumire=="Terapia cu pietre calde").ServiciuID,
                    MembruID=membrii.Single(m=>m.Nume=="Stejeran").Id
                },
                new AlocareServiciu
                {
                    ServiciuID=servicii.Single(c=>c.Denumire=="Mani/Pedi").ServiciuID,
                    MembruID=membrii.Single(m=>m.Nume=="Gherghiceanu").Id
                },
                new AlocareServiciu
                {
                    ServiciuID=servicii.Single(c=>c.Denumire=="Machiaj").ServiciuID,
                    MembruID=membrii.Single(m=>m.Nume=="Stejeran").Id
                },
                new AlocareServiciu
                {
                    ServiciuID=servicii.Single(c=>c.Denumire=="Pensat").ServiciuID,
                    MembruID=membrii.Single(m=>m.Nume=="Stejeran").Id
                },
                new AlocareServiciu
                {
                    ServiciuID=servicii.Single(c=>c.Denumire=="Vopsit").ServiciuID,
                    MembruID=membrii.Single(m=>m.Nume=="Crainic").Id
                },
            };
            foreach (AlocareServiciu asrv in membriiServicii)
            {
                context.AlocariServicii.Add(asrv);
            }
            context.SaveChanges();

            var programari = new Programare[]
            {
                new Programare
                {
                    ClientID=clienti.Single(s=>s.Nume=="Popa").ID,
                    ServiciuID=servicii.Single(c =>c.Denumire=="Tuns par lung").ServiciuID,
                },
                 new Programare
                {
                    ClientID=clienti.Single(s=>s.Nume=="Popa").ID,
                    ServiciuID=servicii.Single(c =>c.Denumire=="Vopsit").ServiciuID,
                },
                 new Programare
                {
                    ClientID=clienti.Single(s=>s.Nume=="Marin").ID,
                    ServiciuID=servicii.Single(c =>c.Denumire=="Aplicare gene").ServiciuID,
                },
                 new Programare
                {
                    ClientID=clienti.Single(s=>s.Nume=="Guias").ID,
                    ServiciuID=servicii.Single(c =>c.Denumire=="Pensat").ServiciuID,
                },
                 new Programare
                {
                    ClientID=clienti.Single(s=>s.Nume=="Guias").ID,
                    ServiciuID=servicii.Single(c =>c.Denumire=="Aplicare gene").ServiciuID,
                },
                 new Programare
                {
                    ClientID=clienti.Single(s=>s.Nume=="Branza").ID,
                    ServiciuID=servicii.Single(c =>c.Denumire=="Mani/Pedi").ServiciuID,
                },
                 new Programare
                {
                    ClientID=clienti.Single(s=>s.Nume=="Cosma").ID,
                    ServiciuID=servicii.Single(c =>c.Denumire=="Tuns par scurt").ServiciuID,
                },
                 new Programare
                {
                    ClientID=clienti.Single(s=>s.Nume=="Lungu").ID,
                    ServiciuID=servicii.Single(c =>c.Denumire=="Terapia cu pietre calde").ServiciuID,
                },
                 new Programare
                {
                    ClientID=clienti.Single(s=>s.Nume=="Florian").ID,
                    ServiciuID=servicii.Single(c =>c.Denumire=="Machiaj").ServiciuID,
                },
                 new Programare
                {
                    ClientID=clienti.Single(s=>s.Nume=="Tocaci").ID,
                    ServiciuID=servicii.Single(c =>c.Denumire=="Aplicare gene").ServiciuID,
                },

            };
            foreach (Programare p in programari)
            {
                var ProgramareInDB = context.Programari.Where(
                    c =>
                        c.Client.ID == p.ClientID &&
                        c.Serviciu.ServiciuID == p.ServiciuID
                        ).SingleOrDefault();
                if (ProgramareInDB == null)
                {
                    context.Programari.Add(p);
                }
            }
        }

    }
}
