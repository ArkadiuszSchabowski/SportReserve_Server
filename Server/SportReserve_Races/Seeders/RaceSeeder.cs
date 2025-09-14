using SportReserve_Races_Db;
using SportReserve_Races_Db.Entities;
using SportReserve_Shared.Interfaces;

namespace SportReserve_Races.Seeders
{
    public class RaceSeeder : ISeeder
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
                            DateOfStart = new DateOnly(2026, 1, 1),
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Manchester, Heaton Park", DistanceKm = 5, HourOfStart = new TimeOnly(10, 0) },
                                new RaceTrace { Location = "Manchester, Heaton Park", DistanceKm = 10, HourOfStart = new TimeOnly(12, 0) },
                                new RaceTrace { Location = "Manchester, Heaton Park", DistanceKm = 15, HourOfStart = new TimeOnly(14, 0) }
                            },
                            PosterUrl = "images/run_for_the_animal_shelter_poster.png",
                            IsRegistrationOpen = true
                        },
                        new Race
                        {
                            Name = "Valentine Race with Heart",
                            Description = "Celebrate Valentine's Day in a truly unique and active way—with a run from the heart! The entry fee is a symbolic £10. Every participant has the option to choose a special Valentine's gadget: a comfortable sports cap, a heart-themed ceramic mug perfect for warm drinks, or a practical shaker. It's the perfect opportunity to share your passion for running with your loved ones and make this holiday truly unforgettable. Join us to run for your health, run for love, and enjoy the magical, festive atmosphere as we spread positive energy together and create lasting memories on the course.",
                            DateOfStart = new DateOnly(2026, 2, 14),
                            EntryFeeGBP = 10,
                            PosterUrl = "images/valentine_race_with_heart_poster.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Liverpool: Albert Dock", DistanceKm = 5, HourOfStart = new TimeOnly(18, 0) },
                                new RaceTrace { Location = "Newcastle: Quayside", DistanceKm = 5, HourOfStart = new TimeOnly(18, 0) },
                                new RaceTrace { Location = "Brighton: Preston Park", DistanceKm = 5, HourOfStart = new TimeOnly(18, 0) }
                            },
                            IsRegistrationOpen = true
                        },
                         new Race
                        {
                            Name = "The Bristol Suspension Bridge Run",
                            Description = "Join this unique race through the vibrant city of Bristol. The route offers spectacular views, including the iconic Clifton Suspension Bridge and the bustling harbourside, where historic ships meet modern street art. This is a chance to run through one of England's most creative and lively cities, feeling the incredible energy of the urban landscape and the heartfelt cheers of the local community. The course is designed to showcase the very best of Bristol, from its historic heart to its contemporary pulse. Whether you are aiming for a personal best or simply want to soak up the atmosphere, this race promises a memorable experience for all.",
                            DateOfStart = new DateOnly(2026, 3, 7),
                            EntryFeeGBP = 20,
                            PosterUrl = "images/the_bristol_suspension_bridge_run_poster.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Bristol, Harbourside", DistanceKm = 10, HourOfStart = new TimeOnly(10, 0) }
                            },
                            IsRegistrationOpen = false
                        },
                        new Race
                        {
                            Name = "London Half-Marathon Race",
                            Description = "Dreaming of a race in the heart of London? The London Half-Marathon Race is your chance! The route will take you past iconic landmarks like Big Ben and the Tower of London, offering a breathtaking tour of the city. The entry fee is £25. During registration, you can choose your t-shirt size from S, M, L, or XL. This is an excellent opportunity to test your endurance and feel the true spirit of London running, surrounded by thousands of fellow runners and cheering crowds. Join us for an unforgettable experience that combines athletic challenge with the unique energy of one of the world's greatest capitals.",
                            DateOfStart = new DateOnly(2026, 3, 10),
                            EntryFeeGBP = 25,
                            PosterUrl = "images/london_half_marathon_race_poster.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "London, Green Park", DistanceKm = 21.1, HourOfStart = new TimeOnly(10, 0) }
                            },
                            IsRegistrationOpen = true
                        },
                        new Race
                        {
                            Name = "The Brighton Seaside Marathon",
                            Description = "Feel the sea breeze and the energy of the crowd in the Brighton Seaside Marathon. This event offers a truly exhilarating and lively experience, as the flat and fast course is perfect for achieving a personal best. The route takes you along the iconic Brighton seafront, with stunning views of the English Channel and the city's historic piers. The entry fee is £45. For an additional £5, you can get a truly unique souvenir: a personalized medal with your name and finish time engraved. This is the ultimate challenge for runners who want to soak up the vibrant atmosphere of a coastal city while pushing their limits. Join us for a marathon that’s as refreshing as it is rewarding!",
                            DateOfStart = new DateOnly(2026, 3, 15),
                            EntryFeeGBP = 45,
                            PosterUrl = "images/the_brighton_seaside_marathon_poster.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Brighton, Madeira Drive", DistanceKm = 42.2, HourOfStart = new TimeOnly(9, 30), Slots = 1500 }
                            }
                        },
                        new Race
                        {
                            Name = "York Minster Trail Run",
                            Description = "Embark on an extraordinary journey back in time, running through the historic heart of York. Feel history beneath your feet as you pass ancient city walls, the impressive York Minster cathedral, and charming medieval streets that tell centuries of stories. Choose one of our distances: a dynamic 5K or a more challenging 10K, perfect for embracing the running challenge. Every participant will receive a unique souvenir: a detailed route map that can serve as a historical artifact, or an elegant guidebook to the city's most important landmarks. This is more than a race; it's an unforgettable history lesson combined with a passion for sport.",
                            DateOfStart = new DateOnly(2026, 3, 22),
                            EntryFeeGBP = 25,
                            PosterUrl = "images/york_minster_trail_run_poster.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "York, Museum Gardens", DistanceKm = 5, HourOfStart = new TimeOnly(9, 0), Slots = 800 },
                                new RaceTrace { Location = "York, Museum Gardens", DistanceKm = 10, HourOfStart = new TimeOnly(12, 0), Slots = 400 }
                            }
                        },
                        new Race
                        {
                            Name = "Lake District Spring Trail Run",
                            Description = "Start your running season in the breathtaking scenery of the Lake District! This trail run offers a challenging route through blooming spring landscapes, where every step is a discovery. Breathe in the crisp, fresh air as you navigate stunning hills and winding paths, surrounded by vibrant wildflowers and lush green scenery. This is a race for those who seek adventure. All finishers will receive a unique, handcrafted gift, with a choice between a beautiful wooden medal that celebrates your achievement or a pouch of local flower seeds to plant a little piece of the Lake District in your own garden. Join us and make your first run of the year an unforgettable one, connecting with nature and fellow runners for a truly rewarding experience.",
                            DateOfStart = new DateOnly(2026, 4, 5),
                            EntryFeeGBP = 30,
                            PosterUrl = "images/lake_district_poster.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Keswick, The Lake District", DistanceKm = 15, HourOfStart = new TimeOnly(10, 0), Slots = 700 }
                            }
                        },
                        new Race
                        {
                            Name = "Manchester City Night Run",
                            Description = "Experience Manchester like never before! The City Night Run is a unique 10K race that takes place after dark. The route winds through the illuminated city center, past iconic landmarks such as Albert Square and the magnificent Manchester Town Hall, all brought to life by the glow of streetlights. This is a chance to see Manchester from a completely new perspective, with the energy of the nightlife providing a powerful backdrop. The atmosphere is electric, filled with a sense of community and exhilaration. You'll run alongside fellow enthusiasts, motivated by the cheering spectators and the pulsing rhythm of the city. This race is more than just a challenge; it's a celebration of urban life and a chance to feel a part of the vibrant heart of Manchester after dark. Join us to light up the night and your running spirit!",
                            DateOfStart = new DateOnly(2026, 4, 24),
                            EntryFeeGBP = 25,
                            PosterUrl = "images/manchester_city_night_run_poster.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Manchester, Piccadilly Gardens", DistanceKm = 10, HourOfStart = new TimeOnly(21, 0), Slots = 1200 }
                            }
                        },
                        new Race
                        {
                            Name = "Edinburgh Castle Charity Run",
                            Description = "Join us for a noble cause at the historic Edinburgh Castle! This is more than a race; it's a chance to run for a cause and help those in need. Feel the energy of the community as you take on the challenge with a purpose. The route winds around the iconic Edinburgh Castle, offering breathtaking views of the city's skyline and the majestic Old Town, making every step a journey through history. During registration, you can choose a special souvenir: a keychain with a beautiful picture of the castle or a lanyard with the race logo. You can also specify which local children's hospital you want to support, knowing that your effort will directly benefit young patients and their families. Your participation truly makes a difference. Sign up today and feel the immense satisfaction of running for a cause greater than yourself, transforming your run into an act of kindness and hope.",
                            DateOfStart = new DateOnly(2026, 5, 18),
                            EntryFeeGBP = 20,
                            PosterUrl = "images/edinburgh_castle_charity_run_poster.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Edinburgh, Holyrood Park", DistanceKm = 5, HourOfStart = new TimeOnly(10, 30), Slots = 600 },
                                new RaceTrace { Location = "Edinburgh, Holyrood Park", DistanceKm = 10, HourOfStart = new TimeOnly(10, 30), Slots = 400 }
                            }
                        },
                        new Race
                        {
                            Name = "Cardiff Vegan Run",
                            Description = "Join us for a unique run through the vibrant city of Cardiff! This is a truly one-of-a-kind event that combines a passion for sports with a plant-based lifestyle. The scenic route takes you through the heart of the city, passing iconic landmarks and green spaces, with an energetic atmosphere that will keep you motivated every step of the way. All participants will receive a high-quality finisher's medal to celebrate their achievement. As a special treat, you can choose a delicious, post-race vegan meal—a hearty vegetable burger, a fresh tofu salad, or tasty falafel—or a voucher to a fantastic local vegan cafe. It's the perfect way to refuel and relax after the run. This is an ideal event for runners who want to connect with a like-minded community and make their love for animals and health a part of their active lifestyle. Join us and run with a purpose!",
                            DateOfStart = new DateOnly(2026, 5, 25),
                            EntryFeeGBP = 25,
                            PosterUrl = "images/cardiff_vegan_run_poster.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Cardiff, Bute Park", DistanceKm = 10, HourOfStart = new TimeOnly(10, 0), Slots = 700 }
                            }
                        },
                        new Race
                        {
                            Name = "Dorset Coastal Path Challenge",
                            Description = "Experience the stunning Jurassic Coast with a trail run offering breathtaking sea views and a challenging route. The path takes you through rolling hills and historic coastal formations, a landscape that tells a story spanning millions of years. Feel the wind on your face and the satisfaction of conquering the challenging terrain, with every turn revealing a new, spectacular view of the English Channel. This event offers two distances: a scenic 10K, perfect for an unforgettable day out, and a more demanding half-marathon, a true test of endurance for those seeking a greater challenge. Whether you're looking to push your limits or simply soak up the incredible natural beauty, this race promises a rewarding and exhilarating experience. Join us and make your mark on one of Britain's most iconic coastal paths!",
                            DateOfStart = new DateOnly(2026, 6, 6),
                            EntryFeeGBP = 30,
                            PosterUrl = "images/dorset_coastal_path_challenge_poster.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Lulworth Cove, Dorset", DistanceKm = 10, HourOfStart = new TimeOnly(9, 0) },
                                new RaceTrace { Location = "Lulworth Cove, Dorset", DistanceKm = 21.1, HourOfStart = new TimeOnly(9, 0) }
                            }
                        },
                        new Race
                        {
                            Name = "Royal Jubilee Run",
                            Description = "Celebrate the King's Birthday Parade in style with a festive run through the royal parks of London. This is a truly unique opportunity to experience the pomp and pageantry of one of London's most famous royal events in a completely new way. The scenic route takes you through the heart of the royal parks, offering spectacular views and a glimpse of the celebratory atmosphere. All participants receive a stunning commemorative medal to honor their achievement and mark this special occasion. For an additional fee, you can get a high-quality race t-shirt, choosing your size from S, M, L, or XL. It's the perfect souvenir to remember your royal adventure. Join us for a run that combines fitness with national celebration. Feel the energy of the crowds and the pride of participating in an event that is truly fit for a king!",
                            DateOfStart = new DateOnly(2026, 6, 13),
                            EntryFeeGBP = 25,
                            PosterUrl = "images/royal_jubilee_run.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "London, St. James's Park", DistanceKm = 10, HourOfStart = new TimeOnly(10, 0) }
                            }
                        },
                        new Race
                        {
                            Name = "Cambridge Midsummer 10K",
                            Description = "Run through the heart of historic Cambridge on one of the longest days of the year. Bask in the golden glow of the midsummer sun as you run past the world-famous colleges and along the scenic River Cam. The festive atmosphere is infectious, with students and locals cheering you on every step of the way. This race is a truly unique experience, combining a love for running with the breathtaking beauty of Cambridge. All participants receive a high-quality race t-shirt, and you can choose your size from S, M, L, or XL during registration. This is your chance to be a part of a special tradition, celebrating the summer solstice in a truly active way. Join us for an unforgettable run that’s as much a sightseeing tour as it is a sporting challenge. Feel the energy of a city steeped in history and academia, all while enjoying the magic of midsummer!",
                            DateOfStart = new DateOnly(2026, 6, 21),
                            EntryFeeGBP = 22,
                            PosterUrl = "images/cambridge_mindsummer_poster.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Cambridge, Midsummer Common", DistanceKm = 10, HourOfStart = new TimeOnly(18, 30), Slots = 1500 }
                            }
                        },
                        new Race
                        {
                            Name = "Leeds City Summer Race",
                            Description = "A fast and flat 10K race through the bustling city centre of Leeds. This is a perfect opportunity to set a new personal best on a course designed for speed. The route takes you past iconic landmarks and through vibrant streets, alive with the energy of the city. Feel the rhythm of the city as you run, with the cheers of the local crowd providing a powerful motivation. All participants will receive a high-quality race t-shirt as a memento of their achievement. You can choose its size from S, M, L, or XL, as well as its color: a classic blue or a clean white. This is your chance to see Leeds from a runner's perspective. Join us for an exhilarating event that combines the thrill of a race with the unique character of one of the UK's most dynamic cities. Sign up now and get ready to run, explore, and conquer Leeds!",
                            DateOfStart = new DateOnly(2026, 7, 12),
                            EntryFeeGBP = 20,
                            PosterUrl = "images/leeds_city_summer_race_poster.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Leeds, Millennium Square", DistanceKm = 10, HourOfStart = new TimeOnly(10, 0), Slots = 1500 }
                            }
                        },
                        new Race
                        {
                            Name = "Devon Coastal Trail Run",
                            Description = "Explore the stunning coastline of Devon with this scenic **15K** trail run. The course offers a challenging but incredibly rewarding route, taking you along dramatic cliff edges and through hidden coves. With every step, you'll be treated to breathtaking sea views and the invigorating scent of the ocean. This is the perfect race for those who love to get off the beaten path and fully immerse themselves in natural beauty. You’ll navigate rolling hills and rugged trails, feeling a deep connection to the ancient landscape of the coast. As a well-deserved souvenir, you can choose between a beautifully hand-illustrated map of the route—a true piece of art to remember your journey—or a small bottle of local Devon cider, a refreshing taste of the region to celebrate your accomplishment. This is a race that will leave you feeling accomplished and rejuvenated. Join us for a day of adventure that combines physical challenge with the pure joy of exploring one of England’s most beautiful coastal regions!",
                            DateOfStart = new DateOnly(2026, 8, 16),
                            EntryFeeGBP = 25,
                            PosterUrl = "images/devon_coastal_trail_run_poster.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Sidmouth, Devon", DistanceKm = 15, HourOfStart = new TimeOnly(9, 30), Slots = 750 }
                            }
                        },
                        new Race
                        {
                            Name = "Newcastle Bridges Half-Marathon",
                            Description = "A flagship event in the North East, this half-marathon takes you on a spectacular journey across Newcastle's famous bridges. The route is a true marvel of urban running, crossing the iconic Tyne Bridge and the stunning Gateshead Millennium Bridge. Experience the incredible energy of the crowds cheering you on every step of the way, as you take in breathtaking views of the Quayside and the River Tyne. This is more than a race; it's a celebration of Newcastle's unique industrial heritage and vibrant modern spirit. For an additional fee of £5, you can get a special gadget to commemorate your achievement: a cozy winter hat with the race logo, perfect for chilly training days, or a practical summer visor to keep the sun out of your eyes. Join us and become a part of the proud running community of the North East!",
                            DateOfStart = new DateOnly(2026, 9, 6),
                            EntryFeeGBP = 35,
                            PosterUrl = "images/newcastle_bridges_half_marathon.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Newcastle, Quayside", DistanceKm = 21.1, HourOfStart = new TimeOnly(10, 0), Slots = 2000 }
                            }
                        },
                        new Race
                        {
                            Name = "Peak District Fell Race",
                            Description = "An incredibly challenging 30K fell race in the rugged and spectacular landscape of the Peak District. This race is for experienced runners only, demanding mental fortitude and physical endurance. The route takes you through steep ascents, rocky trails, and open moorland, where every step is a test of your limits. But the challenge is matched by the reward: breathtaking panoramic views from the highest peaks, misty valleys, and the raw beauty of the English countryside. All participants will be rewarded with a unique prize of their choice to commemorate their monumental achievement: a beautifully crafted, commemorative mountain-shaped statuette or the exclusive 'Peak District Conqueror' badge—a symbol of your triumph over one of Britain's toughest terrains. This is your chance to push your boundaries, connect with nature in its most raw form, and earn your place among the elite fell runners. Join us and prove you have what it takes to conquer the Peaks!",
                            DateOfStart = new DateOnly(2026, 9, 27),
                            EntryFeeGBP = 45,
                            PosterUrl = "images/peak_district_fell_race.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Castleton, Peak District", DistanceKm = 30, HourOfStart = new TimeOnly(8, 0), Slots = 300 }
                            }
                        },
                        new Race
                        {
                            Name = "Halloween Spooktacular Run",
                            Description = "A fun and spooky 5K run for the whole family! Dress up in your best Halloween costume and run through a specially decorated park, transformed into a wonderland of ghoulish delights. The route will be lined with carved pumpkins and eerie lighting, creating a magical and slightly spooky atmosphere. The event features a trick-or-treat station along the course, so get your sweet tooth ready! Don't forget to show off your creativity, as there will be a fancy dress competition with great prizes for the most inventive costumes. This is a perfect way to celebrate Halloween with some light exercise, surrounded by friends, family, and a community that loves to have fun. It’s a non-competitive event where the only goal is to enjoy the festive spirit and make some unforgettable spooky memories. Get ready for a Halloween adventure you won't forget!",
                            DateOfStart = new DateOnly(2026, 10, 31),
                            PosterUrl = "images/halloween_spooktacular_run_poster.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "London, Hyde Park", DistanceKm = 5, HourOfStart = new TimeOnly(18, 0), Slots = 1000 }
                            }
                        },
                        new Race
                        {
                            Name = "Remembrance Day 11K Race",
                            Description = "A poignant and reflective **11K** race to honour the fallen. This is a solemn and inspiring event, a chance to run with purpose and pay your respects. The route will be lined with a sea of poppies, and a moment of silence will be observed before the start, allowing everyone to reflect on the immense sacrifices made. Feel the quiet determination of the community as you run, knowing that every step is a tribute. As a lasting souvenir of your participation, you can choose between a special **Remembrance Day pin**—a small, but powerful symbol of your respect—or a **commemorative candle with a red ribbon**, a symbol of the light of hope and remembrance. A significant portion of the entry fee is donated directly to military charities, ensuring your effort makes a real difference in the lives of those who have served and their families. Join us and turn your run into a powerful act of remembrance, proving that their sacrifices will never be forgotten.",
                            DateOfStart = new DateOnly(2026, 11, 8),
                            EntryFeeGBP = 25,
                            PosterUrl = "images/remembrance_day_race_poster.png",
                            RaceTraces = new List<RaceTrace>
                            {
                                new RaceTrace { Location = "Bristol, Queen Square", DistanceKm = 11, HourOfStart = new TimeOnly(10, 30), Slots = 800 }
                            }
                        },
                        new Race
                        {
                            Name = "Christmas Cracker Fun Run",
                            Description = "Get into the festive spirit with this fun 5K run! This is a non-competitive event perfect for families and friends to enjoy the holiday season together. Run or walk with friends and family, surrounded by cheerful Christmas music and the festive glow of holiday lights. The route will be decorated to spread holiday cheer, making every step a joyful celebration. Every participant receives a Santa hat and a cracker at the finish line, adding to the fun. As a special festive gift to commemorate your run, you can choose between a Santa hat to wear all season long or a beautifully designed advent calendar with the race logo, a delightful daily reminder of your achievement. This is the perfect opportunity to make new holiday traditions and unforgettable memories. Join us and make your race day a festive, family affair that combines light exercise with the pure joy of the holidays. Sign up now and get ready to run, laugh, and celebrate!",
                            DateOfStart = new DateOnly(2026, 12, 19),
                            PosterUrl = "images/christmas_cracker_fun_run_poster.png",
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