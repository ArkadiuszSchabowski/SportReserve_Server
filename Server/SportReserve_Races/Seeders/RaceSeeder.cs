using SportReserve_Races.Interfaces;
using SportReserve_Races_Db;
using SportReserve_Races_Db.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportReserve_Races.Seeders
{
    public class RaceSeeder : IRaceSeeder
    {
        private readonly RaceDbContext _context;

        public RaceSeeder(RaceDbContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            if (_context.Database.CanConnect())
            {
                if (!_context.Races.Any())
                {
                    var races = new List<Race>
                    {
                        new Race
                        {
                            Name = "Run for the Animal Shelter",
                            Description = "Start the New Year with a heart! Take part in the Run for the Animal Shelter and make your first step in 2026 a stride towards good. This is a perfect opportunity to combine your New Year's resolutions with invaluable help for animals in need. During registration, you have the option, but not the obligation, to specify a donation amount, which will be entirely allocated to support local animal shelters. Feel the energy of the community and the satisfaction of running for a noble cause.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 1, 1),
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Manchester, Heaton Park", DistanceKm = 5, HourOfStart = new TimeOnly(10, 0) },
                                new RaceTrace { Location = "Manchester, Heaton Park", DistanceKm = 10, HourOfStart = new TimeOnly(12, 0) }
                            }
                        },
                        new Race
                        {
                            Name = "Valentine Race with Heart",
                            Description = "Celebrate Valentine's Day in a unique way – with an active run from the heart! The entry fee is a symbolic £10. Every participant has the option to choose a special Valentine's gadget: a sports cap, a heart-themed mug, or a shaker.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 2, 14),
                            EntryFeeGBP = 10,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Liverpool: Albert Dock", DistanceKm = 5, HourOfStart = new TimeOnly(18, 0) },
                                new RaceTrace { Location = "Newcastle: Quayside", DistanceKm = 5, HourOfStart = new TimeOnly(18, 0) }
                            }
                        },
                        new Race
                        {
                            Name = "London Half-Marathon Race",
                            Description = "Dreaming of a race in the heart of London? The London Half-Marathon Race is your chance! The entry fee is £25. During registration, you can choose your t-shirt size from S, M, L, or XL. This is an excellent opportunity to test your endurance and feel the true spirit of London running.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 3, 10),
                            EntryFeeGBP = 25,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "London, Green Park", DistanceKm = 21.1, HourOfStart = new TimeOnly(10, 0) }
                            }
                        },
                         new Race
                        {
                            Name = "The Bristol Suspension Bridge Run",
                            Description = "Join this unique race through the vibrant city of Bristol. The route offers spectacular views, including the iconic Clifton Suspension Bridge and the bustling harbourside. This is a chance to run through one of England's most creative and lively cities.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 3, 7),
                            EntryFeeGBP = 20,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Bristol, Harbourside", DistanceKm = 10, HourOfStart = new TimeOnly(10, 0) }
                            }
                        },
                        new Race
                        {
                            Name = "The Brighton Seaside Marathon",
                            Description = "Feel the sea breeze and the energy of the crowd in the Brighton Seaside Marathon. The entry fee is £45. For an additional £5, you can get a personalized medal with your name engraved. It’s an exhilarating and lively event, perfect for runners who want to take on the ultimate challenge.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 3, 15),
                            EntryFeeGBP = 45,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Brighton, Madeira Drive", DistanceKm = 42.2, HourOfStart = new TimeOnly(9, 30), Slots = 1500 }
                            }
                        },
                        new Race
                        {
                            Name = "York Minster Trail Run",
                            Description = "Step back in time with a unique run through the historic heart of York. We offer two distances: a 5K and a more challenging 10K. As a souvenir, you can choose between a historical route map or a guidebook to the city's landmarks.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 3, 22),
                            EntryFeeGBP = 25,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "York, Museum Gardens", DistanceKm = 5, HourOfStart = new TimeOnly(9, 0), Slots = 800 },
                                new RaceTrace { Location = "York, Museum Gardens", DistanceKm = 10, HourOfStart = new TimeOnly(12, 0), Slots = 400 }
                            }
                        },
                        new Race
                        {
                            Name = "Lake District Spring Trail Run",
                            Description = "Start your running season in the breathtaking scenery of the Lake District! This trail run offers a challenging route through blooming spring landscapes. All finishers will receive a unique gift, with a choice between a wooden medal or a pouch of local flower seeds.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 4, 5),
                            EntryFeeGBP = 30,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Keswick, The Lake District", DistanceKm = 15, HourOfStart = new TimeOnly(10, 0), Slots = 700 }
                            }
                        },
                        new Race
                        {
                            Name = "Manchester City Night Run",
                            Description = "Experience Manchester like never before! The City Night Run is a unique 10K race that takes place after dark. The route winds through the illuminated city center, past iconic landmarks such as Albert Square.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 4, 24),
                            EntryFeeGBP = 25,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Manchester, Piccadilly Gardens", DistanceKm = 10, HourOfStart = new TimeOnly(21, 0), Slots = 1200 }
                            }
                        },
                        new Race
                        {
                            Name = "Edinburgh Castle Charity Run",
                            Description = "Join us for a noble cause at the historic Edinburgh Castle! During registration, you can choose a souvenir: a keychain with a picture of the castle or a lanyard with the race logo. You can also specify which local children's hospital you want to support. This is more than a race; it's a chance to run for a cause and help those in need.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 5, 18),
                            EntryFeeGBP = 20,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Edinburgh, Holyrood Park", DistanceKm = 5, HourOfStart = new TimeOnly(10, 30), Slots = 600 },
                                new RaceTrace { Location = "Edinburgh, Holyrood Park", DistanceKm = 10, HourOfStart = new TimeOnly(10, 30), Slots = 400 }
                            }
                        },
                        new Race
                        {
                            Name = "Cardiff Vegan Run",
                            Description = "Join us for a unique run through the vibrant city of Cardiff. All participants will receive a finisher's medal and a choice of a delicious vegan meal (a vegetable burger, tofu salad, or falafel) or a voucher to a local vegan cafe. It's an ideal event for runners who want to combine their passion for sports with a plant-based lifestyle.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 5, 25),
                            EntryFeeGBP = 25,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Cardiff, Bute Park", DistanceKm = 10, HourOfStart = new TimeOnly(10, 0), Slots = 700 }
                            }
                        },
                        new Race
                        {
                            Name = "Cambridge Midsummer 10K",
                            Description = "Run through the heart of historic Cambridge on one of the longest days of the year. All participants receive a t-shirt, and you can choose your size from S, M, L, or XL. The festive midsummer atmosphere, combined with the stunning architecture, makes this race a truly unique experience for all participants.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 6, 21),
                            EntryFeeGBP = 22,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Cambridge, Midsummer Common", DistanceKm = 10, HourOfStart = new TimeOnly(18, 30), Slots = 1500 }
                            }
                        },
                        new Race
                        {
                            Name = "Royal Jubilee Run",
                            Description = "Celebrate the King's Birthday Parade in style with a festive run through the royal parks of London. All participants receive a commemorative medal. For an additional fee, you can get a race t-shirt, choosing your size from S, M, L, or XL.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 6, 13),
                            EntryFeeGBP = 25,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "London, St. James's Park", DistanceKm = 10, HourOfStart = new TimeOnly(10, 0) }
                            }
                        },
                        new Race
                        {
                            Name = "Dorset Coastal Path Challenge",
                            Description = "Experience the stunning Jurassic Coast with a trail run offering breathtaking sea views and a challenging route. The path takes you through rolling hills and historic coastal formations. This event offers two distances: a scenic 10K and a more demanding half-marathon.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 6, 6),
                            EntryFeeGBP = 30,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Lulworth Cove, Dorset", DistanceKm = 10, HourOfStart = new TimeOnly(9, 0) },
                                new RaceTrace { Location = "Lulworth Cove, Dorset", DistanceKm = 21.1, HourOfStart = new TimeOnly(9, 0) }
                            }
                        },
                        new Race
                        {
                            Name = "Leeds City Summer Race",
                            Description = "A fast and flat 10K race through the bustling city centre of Leeds. You will receive a t-shirt, and you can choose its size from S, M, L, or XL, as well as its color: blue or white.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 7, 12),
                            EntryFeeGBP = 20,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Leeds, Millennium Square", DistanceKm = 10, HourOfStart = new TimeOnly(10, 0), Slots = 1500 }
                            }
                        },
                        new Race
                        {
                            Name = "Devon Coastal Trail Run",
                            Description = "Explore the stunning coastline of Devon with this scenic 15K trail run. As a souvenir, you can choose between a hand-illustrated map of the route or a small bottle of local cider. This race is an excellent choice for runners who appreciate natural beauty and a challenging but rewarding course.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 8, 16),
                            EntryFeeGBP = 25,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Sidmouth, Devon", DistanceKm = 15, HourOfStart = new TimeOnly(9, 30), Slots = 750 }
                            }
                        },
                        new Race
                        {
                            Name = "Newcastle Bridges Half-Marathon",
                            Description = "A flagship event in the North East, this half-marathon takes you on a spectacular journey across Newcastle's famous bridges. For an additional fee of £5, you can get a gadget: a winter hat with the race logo or a summer visor.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 9, 6),
                            EntryFeeGBP = 35,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Newcastle, Quayside", DistanceKm = 21.1, HourOfStart = new TimeOnly(10, 0), Slots = 2000 }
                            }
                        },
                        new Race
                        {
                            Name = "Peak District Fell Race",
                            Description = "An incredibly challenging 30K fell race in the rugged and spectacular landscape of the Peak District. This race is for experienced runners only. Participants will be rewarded with a unique prize of their choice: a commemorative mountain-shaped statuette or a 'Peak District Conqueror' badge.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 9, 27),
                            EntryFeeGBP = 45,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Castleton, Peak District", DistanceKm = 30, HourOfStart = new TimeOnly(8, 0), Slots = 300 }
                            }
                        },
                        new Race
                        {
                            Name = "Halloween Spooktacular Run",
                            Description = "A fun and spooky 5K run for the whole family! Dress up in your best Halloween costume and run through a specially decorated park. The event features a trick-or-treat station and a fancy dress competition. A perfect way to celebrate Halloween with some light exercise.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 10, 31),
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "London, Hyde Park", DistanceKm = 5, HourOfStart = new TimeOnly(18, 0), Slots = 1000 }
                            }
                        },
                        new Race
                        {
                            Name = "Remembrance Day 11K Race",
                            Description = "A poignant and reflective 11K race to honour the fallen. As a souvenir, you can choose between a Remembrance Day pin or a commemorative candle with a red ribbon. A portion of the entry fee is donated to military charities.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 11, 8),
                            EntryFeeGBP = 25,
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Bristol, Queen Square", DistanceKm = 11, HourOfStart = new TimeOnly(10, 30), Slots = 800 }
                            }
                        },
                        new Race
                        {
                            Name = "Christmas Cracker Fun Run",
                            Description = "Get into the festive spirit with this fun 5K run! Every participant receives a Santa hat and a cracker at the finish line. As a festive gift, you can choose between a Santa hat or an advent calendar with the race logo. This is a non-competitive event perfect for families and friends to enjoy the holiday season together.",
                            PosterUrl = "url",
                            DateOfStart = new DateOnly(2026, 12, 19),
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Manchester, Heaton Park", DistanceKm = 5, HourOfStart = new TimeOnly(11, 0) }
                            }
                        }
                    };

                    _context.Races.AddRange(races);
                    _context.SaveChanges();
                }
            }
        }
    }
}