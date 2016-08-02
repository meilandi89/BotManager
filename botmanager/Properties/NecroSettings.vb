Namespace Properties
    Public Class NecroSettings
        Public TranslationLanguageCode As String = "en"
'autoupdate
        Public AutoUpdate As Boolean = True
        Public TransferConfigAndAuthOnUpdate As Boolean = True
'pressakeyshit
        Public StartupWelcomeDelay As Boolean = True
'console options
        Public AmountOfPokemonToDisplayOnStart As Integer = 10
        Public ShowPokeballCountsBeforeRecycle As Boolean = True
'powerup
        Public AutomaticallyLevelUpPokemon As Boolean = False
        Public AmountOfTimesToUpgradeLoop As Integer = 5
        Public GetMinStarDustForLevelUp As Integer = 5000
        Public LevelUpByCPorIv As String = "iv"
        Public UpgradePokemonCpMinimum As Single = 1000
        Public UpgradePokemonIvMinimum As Single = 95
'position
        Public DisableHumanWalking As Boolean = False
        Public DefaultAltitude As Double = 10
        Public DefaultLatitude As Double = 40.785091
        Public DefaultLongitude As Double = - 73.968285
        Public WalkingSpeedInKilometerPerHour As Double = 15.0
        Public MaxSpawnLocationOffset As Integer = 10
'delays
        Public DelayBetweenPlayerActions As Integer = 5000
        Public DelayBetweenPokemonCatch As Integer = 2000
'dump stats
        Public DumpPokemonStats As Boolean = False
'evolve
        Public EvolveAboveIvValue As Single = 95
        Public EvolveAllPokemonAboveIv As Boolean = False
        Public EvolveAllPokemonWithEnoughCandy As Boolean = True
        Public KeepPokemonsThatCanEvolve As Boolean = False
        Public EvolveKeptPokemonsAtStorageUsagePercentage As Double = 0.9
'gpx
        Public UseGpxPathing As Boolean = False
        Public GpxFile As String = "GPXPath.GPX"
'recycle
        Public VerboseRecycling As Boolean = True
        Public RecycleInventoryAtUsagePercentage As Double = 0.9
'keeping
        Public KeepMinCp As Integer = 1250
        Public KeepMinDuplicatePokemon As Integer = 1
        Public KeepMinIvPercentage As Single = 90
        Public PrioritizeIvOverCp As Boolean = False
'lucky, incense and berries
        Public UseEggIncubators As Boolean = True
        Public UseLuckyEggConstantly As Boolean = False
        Public UseLuckyEggsMinPokemonAmount As Integer = 30
        Public UseLuckyEggsWhileEvolving As Boolean = False
        Public UseIncenseConstantly As Boolean = False
        Public UseBerriesMinCp As Integer = 1000
        Public UseBerriesMinIv As Single = 90
        Public UseBerriesBelowCatchProbability As Double = 0.2
        Public UseBerriesOperator As String = "and"
'snipe
        Public UseSnipeOnlineLocationServer As Boolean = True
        Public UseSnipeLocationServer As Boolean = False
        Public SnipeLocationServer As String = "localhost"
        Public SnipeLocationServerPort As Integer = 16969
        Public MinPokeballsToSnipe As Integer = 20
        Public MinPokeballsWhileSnipe As Integer = 0
        Public MinDelayBetweenSnipes As Integer = 60000
        Public SnipingScanOffset As Double = 0.003
        Public SnipeAtPokestops As Boolean = False
        Public SnipeIgnoreUnknownIv As Boolean = False
        Public UseTransferIvForSnipe As Boolean = False
'rename
        Public RenamePokemon As Boolean = False
        Public RenameOnlyAboveIv As Boolean = True
        Public RenameTemplate As String = "{1}_{0}"
'amounts
        Public MaxPokeballsPerPokemon As Integer = 6
        Public MaxTravelDistanceInMeters As Integer = 1000
        Public TotalAmountOfPokebalsToKeep As Integer = 120
        Public TotalAmountOfPotionsToKeep As Integer = 80
        Public TotalAmountOfRevivesToKeep As Integer = 60
'balls
        Public UseGreatBallAboveCp As Integer = 1000
        Public UseUltraBallAboveCp As Integer = 1250
        Public UseMasterBallAboveCp As Integer = 1500
        Public UseGreatBallAboveIv As Integer = 85
        Public UseUltraBallAboveIv As Integer = 90
        Public UseGreatBallBelowCatchProbability As Double = 0.3
        Public UseUltraBallBelowCatchProbability As Double = 0.2
        Public UseMasterBallBelowCatchProbability As Double = 0.05
'transfer
        Public TransferDuplicatePokemon As Boolean = True
        Public TransferDuplicatePokemonOnCapture As Boolean = True
'favorite
        Public FavoriteMinIvPercentage As Single = 95
        Public AutoFavoritePokemon As Boolean = False
'notcatch
        Public UsePokemonToNotCatchFilter As Boolean = False
        Public WebSocketPort As Integer = 14251

        Public ItemRecycleFilter As New List(Of KeyValuePair(Of ItemId, Integer))() From { _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemUnknown, 0), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemLuckyEgg, 200), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemIncenseOrdinary, 100), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemIncenseSpicy, 100), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemIncenseCool, 100), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemIncenseFloral, 100), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemTroyDisk, 100), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemXAttack, 100), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemXDefense, 100), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemXMiracle, 100), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemRazzBerry, 50), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemBlukBerry, 10), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemNanabBerry, 10), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemWeparBerry, 30), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemPinapBerry, 30), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemSpecialCamera, 100), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemIncubatorBasicUnlimited, 100), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemIncubatorBasic, 100), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemPokemonStorageUpgrade, 100), _
            New KeyValuePair(Of ItemId, Integer)(ItemId.ItemItemStorageUpgrade, 100) _
            }

        'criteria: from SS Tier to A Tier + Regional Exclusive
        'PokemonId.Golduck,
        'PokemonId.Farfetchd,
        'PokemonId.Kangaskhan,
        'PokemonId.MrMime,
        'PokemonId.Tauros,
        'PokemonId.Lapras,
        'PokemonId.Vaporeon,
        'PokemonId.Jolteon,
        'PokemonId.Flareon,
        'PokemonId.Porygon,
        Public PokemonsNotToTransfer As New List(Of String)() From { _
            "venusaur",
            "charizard",
            "blastoise",
            "nidoqueen",
            "nidoking",
            "clefable",
            "vileplume",
            "arcanine",
            "poliwrath",
            "machamp",
            "victreebel",
            "golem",
            "slowbro",
            "muk",
            "exeggutor",
            "lickitung",
            "chansey",
            "gyarados",
            "ditto",
            "snorlax",
            "articuno",
            "zapdos",
            "moltres",
            "dragonite",
            "mewtwo",
            "mew"
            }

        'NOTE: keep all the end-of-line commas exept for the last one or an exception will be thrown!
'            criteria: 12 candies

        'criteria: 25 candies

        'PokemonId.Bulbasaur,
        'PokemonId.Charmander,
        'PokemonId.Squirtle,
        'PokemonId.NidoranFemale,
        'PokemonId.NidoranMale,
        'PokemonId.Oddish,
        'PokemonId.Poliwag,
        'PokemonId.Abra,
        'PokemonId.Machop,
        'PokemonId.Bellsprout,
        'PokemonId.Geodude,
        'PokemonId.Gastly,
        'PokemonId.Eevee,
        'PokemonId.Dratini,
        'criteria: 50 candies commons

        'PokemonId.Spearow,
        'PokemonId.Ekans,
        'PokemonId.Zubat,
        'PokemonId.Paras,
        'PokemonId.Venonat,
        'PokemonId.Psyduck,
        'PokemonId.Slowpoke,
        'PokemonId.Doduo,
        'PokemonId.Drowzee,
        'PokemonId.Krabby,
        'PokemonId.Horsea,
        'PokemonId.Goldeen,
        'PokemonId.Staryu
        Public PokemonsToEvolve As New List(Of String)() From { _
            "caterpie",
            "weedle",
            "pidgey",
            "rattata"
            }

        'criteria: most common
        Public PokemonsToIgnore As New List(Of String)() From { _
            "caterpie",
            "weedle",
            "pidgey",
            "rattata",
            "spearow",
            "zubat",
            "doduo"
            }

        'criteria: based on NY Central Park and Tokyo variety + sniping optimization
        Public PokemonsTransferFilter As New Dictionary(Of String, TransferFilter) From {
            {"Golduck", New TransferFilter(1800, 95, 1)},
            {"Farfetchd", New TransferFilter(1250, 80, 1)},
            {"Krabby", New TransferFilter(1250, 95, 1)}, _
            {"Kangaskhan", New TransferFilter(1500, 60, 1)},
            {"Horsea", New TransferFilter(1250, 95, 1)},
            {"Staryu", New TransferFilter(1250, 95, 1)},
            {"MrMime", New TransferFilter(1250, 40, 1)},
            {"Scyther", New TransferFilter(1800, 80, 1)},
            {"Jynx", New TransferFilter(1250, 95, 1)},
            {"Electabuzz", New TransferFilter(1250, 80, 1)},
            {"Magmar", New TransferFilter(1500, 80, 1)},
            {"Pinsir", New TransferFilter(1800, 95, 1)},
            {"Tauros", New TransferFilter(1250, 90, 1)},
            {"Magikarp", New TransferFilter(1250, 95, 1)}, 
            {"Gyarados", New TransferFilter(1250, 90, 1)}, 
            {"Lapras", New TransferFilter(1800, 80, 1)}, 
            {"Eevee", New TransferFilter(1250, 95, 1)}, 
            {"Vaporeon", New TransferFilter(1500, 90, 1)}, 
            {"Jolteon", New TransferFilter(1500, 90, 1)}, 
            {"Flareon", New TransferFilter(1500, 90, 1)}, 
            {"Porygon", New TransferFilter(1250, 60, 1)}, 
            {"Snorlax", New TransferFilter(2600, 90, 1)}, 
            {"Dragonite", New TransferFilter(2600, 90, 1)} 
            }

        'Dratini Spot
        'Magikarp Spot
        'Eevee Spot
        'Charmender Spot
        Public PokemonToSnipe As New SnipeSettings() With { _
            .Locations = New List(Of Location)() From { _
            New Location(38.5568074864611, - 121.238379478455),
            New Location(- 33.859019, 151.213098),
            New Location(47.5014969, - 122.0959568),
            New Location(51.5025343, - 0.2055027)
            },
            .Pokemon = New List(Of String)() From {
            "venusaur",
            "charizard",
            "blastoise",
            "beedrill",
            "raichu",
            "sandslash",
            "nidoking",
            "nidoqueen",
            "clefable",
            "ninetales",
            "golbat",
            "vileplume",
            "golduck",
            "primeape",
            "arcanine",
            "poliwrath",
            "alakazam",
            "machamp",
            "golem",
            "rapidash",
            "slowbro",
            "farfetchd",
            "muk",
            "cloyster",
            "gengar",
            "exeggutor",
            "marowak",
            "hitmonchan",
            "lickitung",
            "rhydon",
            "chansey",
            "kangaskhan",
            "starmie",
            "mrMime",
            "scyther",
            "magmar",
            "electabuzz",
            "jynx",
            "gyarados",
            "lapras",
            "ditto",
            "vaporeon",
            "jolteon",
            "flareon",
            "porygon",
            "kabutops",
            "aerodactyl",
            "snorlax",
            "articuno",
            "zapdos",
            "moltres",
            "dragonite",
            "mewtwo",
            "mew"
            }
            }

        Public PokemonToUseMasterball As New List(Of String)() From { _
            "articuno",
            "zapdos",
            "moltres",
            "mew",
            "mewtwo"
            }

        Public Class Location
            Public Sub New()
            End Sub

            Public Sub New(latitude__1 As Double, longitude__2 As Double)
                Latitude = latitude__1
                Longitude = longitude__2
            End Sub

            Public Property Latitude As Double
                Get
                    Return m_Latitude
                End Get
                Set
                    m_Latitude = Value
                End Set
            End Property

            Private m_Latitude As Double

            Public Property Longitude As Double
                Get
                    Return m_Longitude
                End Get
                Set
                    m_Longitude = Value
                End Set
            End Property

            Private m_Longitude As Double
        End Class


        Public Class SnipeSettings
            Public Sub New()
            End Sub

            Public Sub New(locations__1 As List(Of Location), pokemon__2 As List(Of String))
                Locations = locations__1
                Pokemon = pokemon__2
            End Sub

            Public Property Locations As List(Of Location)
                Get
                    Return m_Locations
                End Get
                Set
                    m_Locations = Value
                End Set
            End Property

            Private m_Locations As List(Of Location)

            Public Property Pokemon As List(Of String)
                Get
                    Return m_Pokemon
                End Get
                Set
                    m_Pokemon = Value
                End Set
            End Property

            Private m_Pokemon As List(Of String)
        End Class

        Public Class TransferFilter
            Public Sub New()
            End Sub

            Public Sub New(keepMinCp__1 As Integer, keepMinIvPercentage__2 As Single,
                           keepMinDuplicatePokemon__3 As Integer)
                KeepMinCp = keepMinCp__1
                KeepMinIvPercentage = keepMinIvPercentage__2
                KeepMinDuplicatePokemon = keepMinDuplicatePokemon__3
            End Sub

            Public Property KeepMinCp As Integer
                Get
                    Return m_KeepMinCp
                End Get
                Set
                    m_KeepMinCp = Value
                End Set
            End Property

            Private m_KeepMinCp As Integer

            Public Property KeepMinIvPercentage As Single
                Get
                    Return m_KeepMinIvPercentage
                End Get
                Set
                    m_KeepMinIvPercentage = Value
                End Set
            End Property

            Private m_KeepMinIvPercentage As Single

            Public Property KeepMinDuplicatePokemon As Integer
                Get
                    Return m_KeepMinDuplicatePokemon
                End Get
                Set
                    m_KeepMinDuplicatePokemon = Value
                End Set
            End Property

            Private m_KeepMinDuplicatePokemon As Integer
        End Class

        Public Enum ItemId
            <OriginalName("ITEM_UNKNOWN")> _
            ItemUnknown = 0
            <OriginalName("ITEM_POKE_BALL")> _
            ItemPokeBall = 1
            <OriginalName("ITEM_GREAT_BALL")> _
            ItemGreatBall = 2
            <OriginalName("ITEM_ULTRA_BALL")> _
            ItemUltraBall = 3
            <OriginalName("ITEM_MASTER_BALL")> _
            ItemMasterBall = 4
            <OriginalName("ITEM_POTION")> _
            ItemPotion = 101
            <OriginalName("ITEM_SUPER_POTION")> _
            ItemSuperPotion = 102
            <OriginalName("ITEM_HYPER_POTION")> _
            ItemHyperPotion = 103
            <OriginalName("ITEM_MAX_POTION")> _
            ItemMaxPotion = 104
            <OriginalName("ITEM_REVIVE")> _
            ItemRevive = 201
            <OriginalName("ITEM_MAX_REVIVE")> _
            ItemMaxRevive = 202
            <OriginalName("ITEM_LUCKY_EGG")> _
            ItemLuckyEgg = 301
            <OriginalName("ITEM_INCENSE_ORDINARY")> _
            ItemIncenseOrdinary = 401
            <OriginalName("ITEM_INCENSE_SPICY")> _
            ItemIncenseSpicy = 402
            <OriginalName("ITEM_INCENSE_COOL")> _
            ItemIncenseCool = 403
            <OriginalName("ITEM_INCENSE_FLORAL")> _
            ItemIncenseFloral = 404
            <OriginalName("ITEM_TROY_DISK")> _
            ItemTroyDisk = 501
            <OriginalName("ITEM_X_ATTACK")> _
            ItemXAttack = 602
            <OriginalName("ITEM_X_DEFENSE")> _
            ItemXDefense = 603
            <OriginalName("ITEM_X_MIRACLE")> _
            ItemXMiracle = 604
            <OriginalName("ITEM_RAZZ_BERRY")> _
            ItemRazzBerry = 701
            <OriginalName("ITEM_BLUK_BERRY")> _
            ItemBlukBerry = 702
            <OriginalName("ITEM_NANAB_BERRY")> _
            ItemNanabBerry = 703
            <OriginalName("ITEM_WEPAR_BERRY")> _
            ItemWeparBerry = 704
            <OriginalName("ITEM_PINAP_BERRY")> _
            ItemPinapBerry = 705
            <OriginalName("ITEM_SPECIAL_CAMERA")> _
            ItemSpecialCamera = 801
            <OriginalName("ITEM_INCUBATOR_BASIC_UNLIMITED")> _
            ItemIncubatorBasicUnlimited = 901
            <OriginalName("ITEM_INCUBATOR_BASIC")> _
            ItemIncubatorBasic = 902
            <OriginalName("ITEM_POKEMON_STORAGE_UPGRADE")> _
            ItemPokemonStorageUpgrade = 1001
            <OriginalName("ITEM_ITEM_STORAGE_UPGRADE")> _
            ItemItemStorageUpgrade = 1002
        End Enum

        Public Class OriginalNameAttribute
            Inherits Attribute

            ''' <summary>The name of the element in the .proto file.</summary>
            Public Property Name As String
                Get
                    Return m_Name
                End Get
                Set
                    m_Name = Value
                End Set
            End Property

            Private m_Name As String

            ''' <summary>
            '''     Constructs a new attribute instance for the given name.
            ''' </summary>
            ''' <param name="name">The name of the element in the .proto file.</param>
            Public Sub New(name As String)
                Me.Name = name
            End Sub
        End Class
    End Class
End NameSpace