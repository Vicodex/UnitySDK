using PlayFab.Internal;
using System;
using System.Collections.Generic;

namespace PlayFab.ServerModels
{
    public class AddCharacterVirtualCurrencyRequest
    {

        /// <summary>
        /// PlayFab unique identifier of the user whose virtual currency balance is to be incremented.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Name of the virtual currency which is to be incremented.
        /// </summary>
        public string VirtualCurrency { get; set;}

        /// <summary>
        /// Amount to be added to the character balance of the specified virtual currency. Maximum VC balance is Int32 (2,147,483,647). Any increase over this value will be discarded.
        /// </summary>
        public int Amount { get; set;}
    }

    public class AddSharedGroupMembersRequest
    {

        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId { get; set;}

        /// <summary>
        /// An array of unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public List<string> PlayFabIds { get; set;}
    }

    public class AddSharedGroupMembersResult : PlayFabResultCommon
    {
    }

    public class AddUserVirtualCurrencyRequest
    {

        /// <summary>
        /// PlayFab unique identifier of the user whose virtual currency balance is to be increased.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Name of the virtual currency which is to be incremented.
        /// </summary>
        public string VirtualCurrency { get; set;}

        /// <summary>
        /// Amount to be added to the user balance of the specified virtual currency. Maximum VC balance is Int32 (2,147,483,647). Any increase over this value will be discarded.
        /// </summary>
        public int Amount { get; set;}
    }

    public class AuthenticateSessionTicketRequest
    {

        /// <summary>
        /// Session ticket as issued by a PlayFab client login API.
        /// </summary>
        public string SessionTicket { get; set;}
    }

    public class AuthenticateSessionTicketResult : PlayFabResultCommon
    {

        /// <summary>
        /// Account info for the user whose session ticket was supplied.
        /// </summary>
        public UserAccountInfo UserInfo { get; set;}
    }

    public class AwardSteamAchievementItem
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique Steam achievement name.
        /// </summary>
        public string AchievementName { get; set;}

        /// <summary>
        /// Result of the award attempt (only valid on response, not on request).
        /// </summary>
        public bool Result { get; set;}
    }

    public class AwardSteamAchievementRequest
    {

        /// <summary>
        /// Array of achievements to grant and the users to whom they are to be granted.
        /// </summary>
        public List<AwardSteamAchievementItem> Achievements { get; set;}
    }

    public class AwardSteamAchievementResult : PlayFabResultCommon
    {

        /// <summary>
        /// Array of achievements granted.
        /// </summary>
        public List<AwardSteamAchievementItem> AchievementResults { get; set;}
    }

    /// <summary>
    /// A purchasable item from the item catalog
    /// </summary>
    public class CatalogItem
    {

        /// <summary>
        /// unique identifier for this item
        /// </summary>
        public string ItemId { get; set;}

        /// <summary>
        /// class to which the item belongs
        /// </summary>
        public string ItemClass { get; set;}

        /// <summary>
        /// catalog version for this item
        /// </summary>
        public string CatalogVersion { get; set;}

        /// <summary>
        /// text name for the item, to show in-game
        /// </summary>
        public string DisplayName { get; set;}

        /// <summary>
        /// text description of item, to show in-game
        /// </summary>
        public string Description { get; set;}

        /// <summary>
        /// price of this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}

        /// <summary>
        /// override prices for this item for specific currencies
        /// </summary>
        public Dictionary<string,uint> RealCurrencyPrices { get; set;}

        /// <summary>
        /// list of item tags
        /// </summary>
        public List<string> Tags { get; set;}

        /// <summary>
        /// game specific custom data
        /// </summary>
        public string CustomData { get; set;}

        /// <summary>
        /// defines the consumable properties (number of uses, timeout) for the item
        /// </summary>
        public CatalogItemConsumableInfo Consumable { get; set;}

        /// <summary>
        /// defines the container properties for the item - what items it contains, including random drop tables and virtual currencies, and what item (if any) is required to open it via the UnlockContainerItem API
        /// </summary>
        public CatalogItemContainerInfo Container { get; set;}

        /// <summary>
        /// defines the bundle properties for the item - bundles are items which contain other items, including random drop tables and virtual currencies
        /// </summary>
        public CatalogItemBundleInfo Bundle { get; set;}

        /// <summary>
        /// if true, then an item instance of this type can be used to grant a character to a user.
        /// </summary>
        public bool CanBecomeCharacter { get; set;}

        /// <summary>
        /// if true, then only one item instance of this type will exist and its remaininguses will be incremented instead. RemainingUses will cap out at Int32.Max (2,147,483,647). All subsequent increases will be discarded
        /// </summary>
        public bool IsStackable { get; set;}

        /// <summary>
        /// if true, then an item instance of this type can be traded between players using the trading APIs
        /// </summary>
        public bool IsTradable { get; set;}

        /// <summary>
        /// URL to the item image. For Facebook purchase to display the image on the item purchase page, this must be set to an HTTP URL.
        /// </summary>
        public string ItemImageUrl { get; set;}
    }

    public class CatalogItemBundleInfo
    {

        /// <summary>
        /// unique ItemId values for all items which will be added to the player inventory when the bundle is added
        /// </summary>
        public List<string> BundledItems { get; set;}

        /// <summary>
        /// unique TableId values for all RandomResultTable objects which are part of the bundle (random tables will be resolved and add the relevant items to the player inventory when the bundle is added)
        /// </summary>
        public List<string> BundledResultTables { get; set;}

        /// <summary>
        /// virtual currency types and balances which will be added to the player inventory when the bundle is added
        /// </summary>
        public Dictionary<string,uint> BundledVirtualCurrencies { get; set;}
    }

    public class CatalogItemConsumableInfo
    {

        /// <summary>
        /// number of times this object can be used, after which it will be removed from the player inventory
        /// </summary>
        public uint? UsageCount { get; set;}

        /// <summary>
        /// duration in seconds for how long the item will remain in the player inventory - once elapsed, the item will be removed
        /// </summary>
        public uint? UsagePeriod { get; set;}

        /// <summary>
        /// all inventory item instances in the player inventory sharing a non-null UsagePeriodGroup have their UsagePeriod values added together, and share the result - when that period has elapsed, all the items in the group will be removed
        /// </summary>
        public string UsagePeriodGroup { get; set;}
    }

    /// <summary>
    /// Containers are inventory items that can hold other items defined in the catalog, as well as virtual currency, which is added to the player inventory when the container is unlocked, using the UnlockContainerItem API. The items can be anything defined in the catalog, as well as RandomResultTable objects which will be resolved when the container is unlocked. Containers and their keys should be defined as Consumable (having a limited number of uses) in their catalog defintiions, unless the intent is for the player to be able to re-use them infinitely.
    /// </summary>
    public class CatalogItemContainerInfo
    {

        /// <summary>
        /// ItemId for the catalog item used to unlock the container, if any (if not specified, a call to UnlockContainerItem will open the container, adding the contents to the player inventory and currency balances)
        /// </summary>
        public string KeyItemId { get; set;}

        /// <summary>
        /// unique ItemId values for all items which will be added to the player inventory, once the container has been unlocked
        /// </summary>
        public List<string> ItemContents { get; set;}

        /// <summary>
        /// unique TableId values for all RandomResultTable objects which are part of the container (once unlocked, random tables will be resolved and add the relevant items to the player inventory)
        /// </summary>
        public List<string> ResultTableContents { get; set;}

        /// <summary>
        /// virtual currency types and balances which will be added to the player inventory when the container is unlocked
        /// </summary>
        public Dictionary<string,uint> VirtualCurrencyContents { get; set;}
    }

    public class CharacterLeaderboardEntry
    {

        /// <summary>
        /// PlayFab unique identifier of the user for this leaderboard entry.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// PlayFab unique identifier of the character that belongs to the user for this leaderboard entry.
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Title-specific display name of the character for this leaderboard entry.
        /// </summary>
        public string CharacterName { get; set;}

        /// <summary>
        /// Title-specific display name of the user for this leaderboard entry.
        /// </summary>
        public string DisplayName { get; set;}

        /// <summary>
        /// Name of the character class for this entry.
        /// </summary>
        public string CharacterType { get; set;}

        /// <summary>
        /// Specific value of the user's statistic.
        /// </summary>
        public int StatValue { get; set;}

        /// <summary>
        /// User's overall position in the leaderboard.
        /// </summary>
        public int Position { get; set;}
    }

    public class CharacterResult : PlayFabResultCommon
    {

        /// <summary>
        /// The id for this character on this player.
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// The name of this character.
        /// </summary>
        public string CharacterName { get; set;}

        /// <summary>
        /// The type-string that was given to this character on creation.
        /// </summary>
        public string CharacterType { get; set;}
    }

    public enum CloudScriptRevisionOption
    {
        Live,
        Latest,
        Specific
    }

    public class ConsumeItemRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique instance identifier of the item to be consumed.
        /// </summary>
        public string ItemInstanceId { get; set;}

        /// <summary>
        /// Number of uses to consume from the item.
        /// </summary>
        public int ConsumeCount { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}
    }

    public class ConsumeItemResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique instance identifier of the item with uses consumed.
        /// </summary>
        public string ItemInstanceId { get; set;}

        /// <summary>
        /// Number of uses remaining on the item.
        /// </summary>
        public int RemainingUses { get; set;}
    }

    public class CreateSharedGroupRequest
    {

        /// <summary>
        /// Unique identifier for the shared group (a random identifier will be assigned, if one is not specified).
        /// </summary>
        public string SharedGroupId { get; set;}
    }

    public class CreateSharedGroupResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId { get; set;}
    }

    public enum Currency
    {
        AED,
        AFN,
        ALL,
        AMD,
        ANG,
        AOA,
        ARS,
        AUD,
        AWG,
        AZN,
        BAM,
        BBD,
        BDT,
        BGN,
        BHD,
        BIF,
        BMD,
        BND,
        BOB,
        BRL,
        BSD,
        BTN,
        BWP,
        BYR,
        BZD,
        CAD,
        CDF,
        CHF,
        CLP,
        CNY,
        COP,
        CRC,
        CUC,
        CUP,
        CVE,
        CZK,
        DJF,
        DKK,
        DOP,
        DZD,
        EGP,
        ERN,
        ETB,
        EUR,
        FJD,
        FKP,
        GBP,
        GEL,
        GGP,
        GHS,
        GIP,
        GMD,
        GNF,
        GTQ,
        GYD,
        HKD,
        HNL,
        HRK,
        HTG,
        HUF,
        IDR,
        ILS,
        IMP,
        INR,
        IQD,
        IRR,
        ISK,
        JEP,
        JMD,
        JOD,
        JPY,
        KES,
        KGS,
        KHR,
        KMF,
        KPW,
        KRW,
        KWD,
        KYD,
        KZT,
        LAK,
        LBP,
        LKR,
        LRD,
        LSL,
        LYD,
        MAD,
        MDL,
        MGA,
        MKD,
        MMK,
        MNT,
        MOP,
        MRO,
        MUR,
        MVR,
        MWK,
        MXN,
        MYR,
        MZN,
        NAD,
        NGN,
        NIO,
        NOK,
        NPR,
        NZD,
        OMR,
        PAB,
        PEN,
        PGK,
        PHP,
        PKR,
        PLN,
        PYG,
        QAR,
        RON,
        RSD,
        RUB,
        RWF,
        SAR,
        SBD,
        SCR,
        SDG,
        SEK,
        SGD,
        SHP,
        SLL,
        SOS,
        SPL,
        SRD,
        STD,
        SVC,
        SYP,
        SZL,
        THB,
        TJS,
        TMT,
        TND,
        TOP,
        TRY,
        TTD,
        TVD,
        TWD,
        TZS,
        UAH,
        UGX,
        USD,
        UYU,
        UZS,
        VEF,
        VND,
        VUV,
        WST,
        XAF,
        XCD,
        XDR,
        XOF,
        XPF,
        YER,
        ZAR,
        ZMW,
        ZWD
    }

    public class DeleteCharacterFromUserRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// If true, the character's inventory will be transferred up to the owning user; otherwise, this request will purge those items.
        /// </summary>
        public bool SaveCharacterInventory { get; set;}
    }

    public class DeleteCharacterFromUserResult : PlayFabResultCommon
    {
    }

    public class DeleteSharedGroupRequest
    {

        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId { get; set;}
    }

    public class DeleteUsersRequest
    {

        /// <summary>
        /// An array of unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public List<string> PlayFabIds { get; set;}

        /// <summary>
        /// Unique identifier for the title, found in the Settings > Game Properties section of the PlayFab developer site when a title has been selected
        /// </summary>
        public string TitleId { get; set;}
    }

    public class DeleteUsersResult : PlayFabResultCommon
    {
    }

    public class EmptyResult : PlayFabResultCommon
    {
    }

    public class EvaluateRandomResultTableRequest : PlayFabResultCommon
    {

        /// <summary>
        /// The unique identifier of the Random Result Table to use.
        /// </summary>
        public string TableId { get; set;}

        /// <summary>
        /// Specifies the catalog version that should be used to evaluate the Random Result Table.  If unspecified, uses default/primary catalog.
        /// </summary>
        public string CatalogVersion { get; set;}
    }

    public class EvaluateRandomResultTableResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique identifier for the item returned from the Random Result Table evaluation, for the given catalog.
        /// </summary>
        public string ResultItemId { get; set;}
    }

    public class ExecuteCloudScriptResult : PlayFabResultCommon
    {

        /// <summary>
        /// The name of the function that executed
        /// </summary>
        public string FunctionName { get; set;}

        /// <summary>
        /// The revision of the CloudScript that executed
        /// </summary>
        public int Revision { get; set;}

        /// <summary>
        /// The object returned from the CloudScript function, if any
        /// </summary>
        public object FunctionResult { get; set;}

        /// <summary>
        /// Entries logged during the function execution. These include both entries logged in the function code using log.info() and log.error() and error entries for API and HTTP request failures.
        /// </summary>
        public List<LogStatement> Logs { get; set;}

        public double ExecutionTimeSeconds { get; set;}

        public uint MemoryConsumedBytes { get; set;}

        /// <summary>
        /// Number of PlayFab API requests issued by the CloudScript function
        /// </summary>
        public int APIRequestsIssued { get; set;}

        /// <summary>
        /// Number of external HTTP requests issued by the CloudScript function
        /// </summary>
        public int HttpRequestsIssued { get; set;}

        /// <summary>
        /// Information about the error, if any, that occured during execution
        /// </summary>
        public ScriptExecutionError Error { get; set;}
    }

    public class ExecuteCloudScriptServerRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// The name of the CloudScript function to execute
        /// </summary>
        public string FunctionName { get; set;}

        /// <summary>
        /// Object that is passed in to the function as the first argument
        /// </summary>
        public object FunctionParameter { get; set;}

        /// <summary>
        /// Option for which revision of the CloudScript to execute. 'Latest' executes the most recently created revision, 'Live' executes the current live, published revision, and 'Specific' executes the specified revision. The default value is 'Specific', if the SpeificRevision parameter is specified, otherwise it is 'Live'.
        /// </summary>
        public CloudScriptRevisionOption? RevisionSelection { get; set;}

        /// <summary>
        /// The specivic revision to execute, when RevisionSelection is set to 'Specific'
        /// </summary>
        public int? SpecificRevision { get; set;}

        /// <summary>
        /// Generate a 'player_executed_cloudscript' PlayStream event containing the results of the function execution and other contextual information. This event will show up in the PlayStream debugger console for the player in Game Manager.
        /// </summary>
        public bool? GeneratePlayStreamEvent { get; set;}
    }

    public class FacebookPlayFabIdPair
    {

        /// <summary>
        /// Unique Facebook identifier for a user.
        /// </summary>
        public string FacebookId { get; set;}

        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Facebook identifier.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    public class FriendInfo
    {

        /// <summary>
        /// PlayFab unique identifier for this friend.
        /// </summary>
        public string FriendPlayFabId { get; set;}

        /// <summary>
        /// PlayFab unique username for this friend.
        /// </summary>
        public string Username { get; set;}

        /// <summary>
        /// Title-specific display name for this friend.
        /// </summary>
        public string TitleDisplayName { get; set;}

        /// <summary>
        /// Tags which have been associated with this friend.
        /// </summary>
        public List<string> Tags { get; set;}

        /// <summary>
        /// Unique lobby identifier of the Game Server Instance to which this player is currently connected.
        /// </summary>
        public string CurrentMatchmakerLobbyId { get; set;}

        /// <summary>
        /// Available Facebook information (if the user and PlayFab friend are also connected in Facebook).
        /// </summary>
        public UserFacebookInfo FacebookInfo { get; set;}

        /// <summary>
        /// Available Steam information (if the user and PlayFab friend are also connected in Steam).
        /// </summary>
        public UserSteamInfo SteamInfo { get; set;}

        /// <summary>
        /// Available Game Center information (if the user and PlayFab friend are also connected in Game Center).
        /// </summary>
        public UserGameCenterInfo GameCenterInfo { get; set;}
    }

    public enum GameInstanceState
    {
        Open,
        Closed
    }

    public class GetCatalogItemsRequest
    {

        /// <summary>
        /// Which catalog is being requested.
        /// </summary>
        public string CatalogVersion { get; set;}
    }

    public class GetCatalogItemsResult : PlayFabResultCommon
    {

        /// <summary>
        /// Array of items which can be purchased.
        /// </summary>
        public List<CatalogItem> Catalog { get; set;}
    }

    public class GetCharacterDataRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Specific keys to search for in the custom user data.
        /// </summary>
        public List<string> Keys { get; set;}

        /// <summary>
        /// The version that currently exists according to the caller. The call will return the data for all of the keys if the version in the system is greater than this.
        /// </summary>
        public int? IfChangedFromDataVersion { get; set;}
    }

    public class GetCharacterDataResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion { get; set;}

        /// <summary>
        /// User specific data for this title.
        /// </summary>
        public Dictionary<string,UserDataRecord> Data { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}
    }

    public class GetCharacterInventoryRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Used to limit results to only those from a specific catalog version.
        /// </summary>
        public string CatalogVersion { get; set;}
    }

    public class GetCharacterInventoryResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique identifier of the character for this inventory.
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Array of inventory items belonging to the character.
        /// </summary>
        public List<ItemInstance> Inventory { get; set;}

        /// <summary>
        /// Array of virtual currency balance(s) belonging to the character.
        /// </summary>
        public Dictionary<string,int> VirtualCurrency { get; set;}

        /// <summary>
        /// Array of remaining times and timestamps for virtual currencies.
        /// </summary>
        public Dictionary<string,VirtualCurrencyRechargeTime> VirtualCurrencyRechargeTimes { get; set;}
    }

    public class GetCharacterLeaderboardRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Optional character type on which to filter the leaderboard entries.
        /// </summary>
        public string CharacterType { get; set;}

        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// First entry in the leaderboard to be retrieved.
        /// </summary>
        public int StartPosition { get; set;}

        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount { get; set;}
    }

    public class GetCharacterLeaderboardResult : PlayFabResultCommon
    {

        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<CharacterLeaderboardEntry> Leaderboard { get; set;}
    }

    public class GetCharacterStatisticsRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}
    }

    public class GetCharacterStatisticsResult : PlayFabResultCommon
    {

        /// <summary>
        /// PlayFab unique identifier of the user whose character statistics are being returned.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique identifier of the character for the statistics.
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Character statistics for the requested user.
        /// </summary>
        public Dictionary<string,int> CharacterStatistics { get; set;}
    }

    public class GetContentDownloadUrlRequest
    {

        /// <summary>
        /// Key of the content item to fetch, usually formatted as a path, e.g. images/a.png
        /// </summary>
        public string Key { get; set;}

        /// <summary>
        /// HTTP method to fetch item - GET or HEAD. Use HEAD when only fetching metadata. Default is GET.
        /// </summary>
        public string HttpMethod { get; set;}

        /// <summary>
        /// True if download through CDN. CDN provides better download bandwidth and time. However, if you want latest, non-cached version of the content, set this to false. Default is true.
        /// </summary>
        public bool? ThruCDN { get; set;}
    }

    public class GetContentDownloadUrlResult : PlayFabResultCommon
    {

        /// <summary>
        /// URL for downloading content via HTTP GET or HEAD method. The URL will expire in 1 hour.
        /// </summary>
        public string URL { get; set;}
    }

    public class GetLeaderboardAroundCharacterRequest
    {

        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Optional character type on which to filter the leaderboard entries.
        /// </summary>
        public string CharacterType { get; set;}

        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount { get; set;}
    }

    public class GetLeaderboardAroundCharacterResult : PlayFabResultCommon
    {

        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<CharacterLeaderboardEntry> Leaderboard { get; set;}
    }

    public class GetLeaderboardAroundUserRequest
    {

        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount { get; set;}
    }

    public class GetLeaderboardAroundUserResult : PlayFabResultCommon
    {

        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
    }

    public class GetLeaderboardForUsersCharactersRequest
    {

        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount { get; set;}
    }

    public class GetLeaderboardForUsersCharactersResult : PlayFabResultCommon
    {

        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<CharacterLeaderboardEntry> Leaderboard { get; set;}
    }

    public class GetLeaderboardRequest
    {

        /// <summary>
        /// Unique identifier for the title-specific statistic for the leaderboard.
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// First entry in the leaderboard to be retrieved.
        /// </summary>
        public int StartPosition { get; set;}

        /// <summary>
        /// Maximum number of entries to retrieve.
        /// </summary>
        public int MaxResultsCount { get; set;}
    }

    public class GetLeaderboardResult : PlayFabResultCommon
    {

        /// <summary>
        /// Ordered list of leaderboard entries.
        /// </summary>
        public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
    }

    public class GetPlayerStatisticsRequest
    {

        /// <summary>
        /// user for whom statistics are being requested
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// statistics to return
        /// </summary>
        public List<string> StatisticNames { get; set;}

        /// <summary>
        /// statistics to return, if StatisticNames is not set (only statistics which have a version matching that provided will be returned)
        /// </summary>
        public List<StatisticNameVersion> StatisticNameVersions { get; set;}
    }

    public class GetPlayerStatisticsResult : PlayFabResultCommon
    {

        /// <summary>
        /// PlayFab unique identifier of the user whose statistics are being returned
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// User statistics for the requested user.
        /// </summary>
        public List<StatisticValue> Statistics { get; set;}
    }

    public class GetPlayerStatisticVersionsRequest
    {

        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName { get; set;}
    }

    public class GetPlayerStatisticVersionsResult : PlayFabResultCommon
    {

        /// <summary>
        /// version change history of the statistic
        /// </summary>
        public List<PlayerStatisticVersion> StatisticVersions { get; set;}
    }

    public class GetPlayFabIDsFromFacebookIDsRequest
    {

        /// <summary>
        /// Array of unique Facebook identifiers for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> FacebookIDs { get; set;}
    }

    public class GetPlayFabIDsFromFacebookIDsResult : PlayFabResultCommon
    {

        /// <summary>
        /// Mapping of Facebook identifiers to PlayFab identifiers.
        /// </summary>
        public List<FacebookPlayFabIdPair> Data { get; set;}
    }

    public class GetPlayFabIDsFromSteamIDsRequest
    {

        /// <summary>
        /// Deprecated: Please use SteamStringIDs
        /// </summary>
        public List<ulong> SteamIDs { get; set;}

        /// <summary>
        /// Array of unique Steam identifiers (Steam profile IDs) for which the title needs to get PlayFab identifiers.
        /// </summary>
        public List<string> SteamStringIDs { get; set;}
    }

    public class GetPlayFabIDsFromSteamIDsResult : PlayFabResultCommon
    {

        /// <summary>
        /// Mapping of Steam identifiers to PlayFab identifiers.
        /// </summary>
        public List<SteamPlayFabIdPair> Data { get; set;}
    }

    public class GetPublisherDataRequest
    {

        /// <summary>
        ///  array of keys to get back data from the Publisher data blob, set by the admin tools
        /// </summary>
        public List<string> Keys { get; set;}
    }

    public class GetPublisherDataResult : PlayFabResultCommon
    {

        /// <summary>
        /// a dictionary object of key / value pairs
        /// </summary>
        public Dictionary<string,string> Data { get; set;}
    }

    public class GetSharedGroupDataRequest
    {

        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId { get; set;}

        /// <summary>
        /// Specific keys to retrieve from the shared group (if not specified, all keys will be returned, while an empty array indicates that no keys should be returned).
        /// </summary>
        public List<string> Keys { get; set;}

        /// <summary>
        /// If true, return the list of all members of the shared group.
        /// </summary>
        public bool? GetMembers { get; set;}
    }

    public class GetSharedGroupDataResult : PlayFabResultCommon
    {

        /// <summary>
        /// Data for the requested keys.
        /// </summary>
        public Dictionary<string,SharedGroupDataRecord> Data { get; set;}

        /// <summary>
        /// List of PlayFabId identifiers for the members of this group, if requested.
        /// </summary>
        public List<string> Members { get; set;}
    }

    public class GetTitleDataRequest
    {

        /// <summary>
        /// Specific keys to search for in the title data (leave null to get all keys)
        /// </summary>
        public List<string> Keys { get; set;}
    }

    public class GetTitleDataResult : PlayFabResultCommon
    {

        /// <summary>
        /// a dictionary object of key / value pairs
        /// </summary>
        public Dictionary<string,string> Data { get; set;}
    }

    public class GetTitleNewsRequest
    {

        /// <summary>
        /// Limits the results to the last n entries. Defaults to 10 if not set.
        /// </summary>
        public int? Count { get; set;}
    }

    public class GetTitleNewsResult : PlayFabResultCommon
    {

        /// <summary>
        /// Array of news items.
        /// </summary>
        public List<TitleNewsItem> News { get; set;}
    }

    public class GetUserAccountInfoRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    public class GetUserAccountInfoResult : PlayFabResultCommon
    {

        /// <summary>
        /// Account details for the user whose information was requested.
        /// </summary>
        public UserAccountInfo UserInfo { get; set;}
    }

    public class GetUserDataRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Specific keys to search for in the custom user data.
        /// </summary>
        public List<string> Keys { get; set;}

        /// <summary>
        /// The version that currently exists according to the caller. The call will return the data for all of the keys if the version in the system is greater than this.
        /// </summary>
        public int? IfChangedFromDataVersion { get; set;}
    }

    public class GetUserDataResult : PlayFabResultCommon
    {

        /// <summary>
        /// PlayFab unique identifier of the user whose custom data is being returned.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion { get; set;}

        /// <summary>
        /// User specific data for this title.
        /// </summary>
        public Dictionary<string,UserDataRecord> Data { get; set;}
    }

    public class GetUserInventoryRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    public class GetUserInventoryResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Array of inventory items belonging to the user.
        /// </summary>
        public List<ItemInstance> Inventory { get; set;}

        /// <summary>
        /// Array of virtual currency balance(s) belonging to the user.
        /// </summary>
        public Dictionary<string,int> VirtualCurrency { get; set;}

        /// <summary>
        /// Array of remaining times and timestamps for virtual currencies.
        /// </summary>
        public Dictionary<string,VirtualCurrencyRechargeTime> VirtualCurrencyRechargeTimes { get; set;}
    }

    public class GetUserStatisticsRequest
    {

        /// <summary>
        /// User for whom statistics are being requested.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    public class GetUserStatisticsResult : PlayFabResultCommon
    {

        /// <summary>
        /// PlayFab unique identifier of the user whose statistics are being returned.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// User statistics for the requested user.
        /// </summary>
        public Dictionary<string,int> UserStatistics { get; set;}
    }

    public class GrantCharacterToUserRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Non-unique display name of the character being granted.
        /// </summary>
        public string CharacterName { get; set;}

        /// <summary>
        /// Type of the character being granted; statistics can be sliced based on this value.
        /// </summary>
        public string CharacterType { get; set;}
    }

    public class GrantCharacterToUserResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique identifier tagged to this character.
        /// </summary>
        public string CharacterId { get; set;}
    }

    /// <summary>
    /// Result of granting an item to a user
    /// </summary>
    public class GrantedItemInstance
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Result of this operation.
        /// </summary>
        public bool Result { get; set;}

        /// <summary>
        /// Unique identifier for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemId { get; set;}

        /// <summary>
        /// Unique item identifier for this specific instance of the item.
        /// </summary>
        public string ItemInstanceId { get; set;}

        /// <summary>
        /// Class name for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemClass { get; set;}

        /// <summary>
        /// Timestamp for when this instance was purchased.
        /// </summary>
        public DateTime? PurchaseDate { get; set;}

        /// <summary>
        /// Timestamp for when this instance will expire.
        /// </summary>
        public DateTime? Expiration { get; set;}

        /// <summary>
        /// Total number of remaining uses, if this is a consumable item.
        /// </summary>
        public int? RemainingUses { get; set;}

        /// <summary>
        /// The number of uses that were added or removed to this item in this call.
        /// </summary>
        public int? UsesIncrementedBy { get; set;}

        /// <summary>
        /// Game specific comment associated with this instance when it was added to the user inventory.
        /// </summary>
        public string Annotation { get; set;}

        /// <summary>
        /// Catalog version for the inventory item, when this instance was created.
        /// </summary>
        public string CatalogVersion { get; set;}

        /// <summary>
        /// Unique identifier for the parent inventory item, as defined in the catalog, for object which were added from a bundle or container.
        /// </summary>
        public string BundleParent { get; set;}

        /// <summary>
        /// CatalogItem.DisplayName at the time this item was purchased.
        /// </summary>
        public string DisplayName { get; set;}

        /// <summary>
        /// Currency type for the cost of the catalog item.
        /// </summary>
        public string UnitCurrency { get; set;}

        /// <summary>
        /// Cost of the catalog item in the given currency.
        /// </summary>
        public uint UnitPrice { get; set;}

        /// <summary>
        /// Array of unique items that were awarded when this catalog item was purchased.
        /// </summary>
        public List<string> BundleContents { get; set;}

        /// <summary>
        /// A set of custom key-value pairs on the inventory item.
        /// </summary>
        public Dictionary<string,string> CustomData { get; set;}
    }

    public class GrantItemsToCharacterRequest
    {

        /// <summary>
        /// Catalog version from which items are to be granted.
        /// </summary>
        public string CatalogVersion { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// String detailing any additional information concerning this operation.
        /// </summary>
        public string Annotation { get; set;}

        /// <summary>
        /// Array of itemIds to grant to the user.
        /// </summary>
        public List<string> ItemIds { get; set;}
    }

    public class GrantItemsToCharacterResult : PlayFabResultCommon
    {

        /// <summary>
        /// Array of items granted to users.
        /// </summary>
        public List<GrantedItemInstance> ItemGrantResults { get; set;}
    }

    public class GrantItemsToUserRequest
    {

        /// <summary>
        /// Catalog version from which items are to be granted.
        /// </summary>
        public string CatalogVersion { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// String detailing any additional information concerning this operation.
        /// </summary>
        public string Annotation { get; set;}

        /// <summary>
        /// Array of itemIds to grant to the user.
        /// </summary>
        public List<string> ItemIds { get; set;}
    }

    public class GrantItemsToUserResult : PlayFabResultCommon
    {

        /// <summary>
        /// Array of items granted to users.
        /// </summary>
        public List<GrantedItemInstance> ItemGrantResults { get; set;}
    }

    public class GrantItemsToUsersRequest
    {

        /// <summary>
        /// Catalog version from which items are to be granted.
        /// </summary>
        public string CatalogVersion { get; set;}

        /// <summary>
        /// Array of items to grant and the users to whom the items are to be granted.
        /// </summary>
        public List<ItemGrant> ItemGrants { get; set;}
    }

    public class GrantItemsToUsersResult : PlayFabResultCommon
    {

        /// <summary>
        /// Array of items granted to users.
        /// </summary>
        public List<GrantedItemInstance> ItemGrantResults { get; set;}
    }

    public class ItemGrant
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique identifier of the catalog item to be granted to the user.
        /// </summary>
        public string ItemId { get; set;}

        /// <summary>
        /// String detailing any additional information concerning this operation.
        /// </summary>
        public string Annotation { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}
    }

    /// <summary>
    /// A unique instance of an item in a user's inventory
    /// </summary>
    public class ItemInstance
    {

        /// <summary>
        /// Unique identifier for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemId { get; set;}

        /// <summary>
        /// Unique item identifier for this specific instance of the item.
        /// </summary>
        public string ItemInstanceId { get; set;}

        /// <summary>
        /// Class name for the inventory item, as defined in the catalog.
        /// </summary>
        public string ItemClass { get; set;}

        /// <summary>
        /// Timestamp for when this instance was purchased.
        /// </summary>
        public DateTime? PurchaseDate { get; set;}

        /// <summary>
        /// Timestamp for when this instance will expire.
        /// </summary>
        public DateTime? Expiration { get; set;}

        /// <summary>
        /// Total number of remaining uses, if this is a consumable item.
        /// </summary>
        public int? RemainingUses { get; set;}

        /// <summary>
        /// The number of uses that were added or removed to this item in this call.
        /// </summary>
        public int? UsesIncrementedBy { get; set;}

        /// <summary>
        /// Game specific comment associated with this instance when it was added to the user inventory.
        /// </summary>
        public string Annotation { get; set;}

        /// <summary>
        /// Catalog version for the inventory item, when this instance was created.
        /// </summary>
        public string CatalogVersion { get; set;}

        /// <summary>
        /// Unique identifier for the parent inventory item, as defined in the catalog, for object which were added from a bundle or container.
        /// </summary>
        public string BundleParent { get; set;}

        /// <summary>
        /// CatalogItem.DisplayName at the time this item was purchased.
        /// </summary>
        public string DisplayName { get; set;}

        /// <summary>
        /// Currency type for the cost of the catalog item.
        /// </summary>
        public string UnitCurrency { get; set;}

        /// <summary>
        /// Cost of the catalog item in the given currency.
        /// </summary>
        public uint UnitPrice { get; set;}

        /// <summary>
        /// Array of unique items that were awarded when this catalog item was purchased.
        /// </summary>
        public List<string> BundleContents { get; set;}

        /// <summary>
        /// A set of custom key-value pairs on the inventory item.
        /// </summary>
        public Dictionary<string,string> CustomData { get; set;}
    }

    public class ListUsersCharactersRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    public class ListUsersCharactersResult : PlayFabResultCommon
    {

        /// <summary>
        /// The requested list of characters.
        /// </summary>
        public List<CharacterResult> Characters { get; set;}
    }

    public class LogEventRequest
    {

        /// <summary>
        /// PlayFab User Id of the player associated with this event. For non-player associated events, this must be null and EntityId must be set.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// For non player-associated events, a unique ID for the entity associated with this event. For player associated events, this must be null and PlayFabId must be set.
        /// </summary>
        public string EntityId { get; set;}

        /// <summary>
        /// For non player-associated events, the type of entity associated with this event. For player associated events, this must be null.
        /// </summary>
        public string EntityType { get; set;}

        /// <summary>
        /// Optional timestamp for this event. If null, the a timestamp is auto-assigned to the event on the server.
        /// </summary>
        public DateTime? Timestamp { get; set;}

        /// <summary>
        /// A unique event name which will be used as the table name in the Redshift database. The name will be made lower case, and cannot not contain spaces. The use of underscores is recommended, for readability. Events also cannot match reserved terms. The PlayFab reserved terms are 'log_in' and 'purchase', 'create' and 'request', while the Redshift reserved terms can be found here: http://docs.aws.amazon.com/redshift/latest/dg/r_pg_keywords.html.
        /// </summary>
        public string EventName { get; set;}

        /// <summary>
        /// Contains all the data for this event. Event Values can be strings, booleans or numerics (float, double, integer, long) and must be consistent on a per-event basis (if the Value for Key 'A' in Event 'Foo' is an integer the first time it is sent, it must be an integer in all subsequent 'Foo' events). As with event names, Keys must also not use reserved words (see above). Finally, the size of the Body for an event must be less than 32KB (UTF-8 format).
        /// </summary>
        public Dictionary<string,object> Body { get; set;}

        /// <summary>
        /// Flag to set event Body as profile details in the Redshift database as well as a standard event.
        /// </summary>
        public bool ProfileSetEvent { get; set;}
    }

    public class LogEventResult : PlayFabResultCommon
    {
    }

    public class LogStatement
    {

        /// <summary>
        /// 'Debug', 'Info', or 'Error'
        /// </summary>
        public string Level { get; set;}

        public string Message { get; set;}

        /// <summary>
        /// Optional object accompanying the message as contextual information
        /// </summary>
        public object Data { get; set;}
    }

    public class ModifyCharacterVirtualCurrencyResult : PlayFabResultCommon
    {

        /// <summary>
        /// Name of the virtual currency which was modified.
        /// </summary>
        public string VirtualCurrency { get; set;}

        /// <summary>
        /// Balance of the virtual currency after modification.
        /// </summary>
        public int Balance { get; set;}
    }

    public class ModifyItemUsesRequest
    {

        /// <summary>
        /// PlayFab unique identifier of the user whose item is being modified.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique instance identifier of the item to be modified.
        /// </summary>
        public string ItemInstanceId { get; set;}

        /// <summary>
        /// Number of uses to add to the item. Can be negative to remove uses.
        /// </summary>
        public int UsesToAdd { get; set;}
    }

    public class ModifyItemUsesResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique instance identifier of the item with uses consumed.
        /// </summary>
        public string ItemInstanceId { get; set;}

        /// <summary>
        /// Number of uses remaining on the item.
        /// </summary>
        public int RemainingUses { get; set;}
    }

    public class ModifyUserVirtualCurrencyResult : PlayFabResultCommon
    {

        /// <summary>
        /// User currency was subtracted from.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Name of the virtual currency which was modified.
        /// </summary>
        public string VirtualCurrency { get; set;}

        /// <summary>
        /// Amount added or subtracted from the user's virtual currency. Maximum VC balance is Int32 (2,147,483,647). Any increase over this value will be discarded.
        /// </summary>
        public int BalanceChange { get; set;}

        /// <summary>
        /// Balance of the virtual currency after modification.
        /// </summary>
        public int Balance { get; set;}
    }

    public class MoveItemToCharacterFromCharacterRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique identifier of the character that currently has the item.
        /// </summary>
        public string GivingCharacterId { get; set;}

        /// <summary>
        /// Unique identifier of the character that will be receiving the item.
        /// </summary>
        public string ReceivingCharacterId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId { get; set;}
    }

    public class MoveItemToCharacterFromCharacterResult : PlayFabResultCommon
    {
    }

    public class MoveItemToCharacterFromUserRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId { get; set;}
    }

    public class MoveItemToCharacterFromUserResult : PlayFabResultCommon
    {
    }

    public class MoveItemToUserFromCharacterRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId { get; set;}
    }

    public class MoveItemToUserFromCharacterResult : PlayFabResultCommon
    {
    }

    public class NotifyMatchmakerPlayerLeftRequest
    {

        /// <summary>
        /// Unique identifier of the Game Instance the user is leaving.
        /// </summary>
        public string LobbyId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    public class NotifyMatchmakerPlayerLeftResult : PlayFabResultCommon
    {

        /// <summary>
        /// State of user leaving the Game Server Instance.
        /// </summary>
        public PlayerConnectionState? PlayerState { get; set;}
    }

    public enum PlayerConnectionState
    {
        Unassigned,
        Connecting,
        Participating,
        Participated,
        Reconnecting
    }

    public class PlayerLeaderboardEntry
    {

        /// <summary>
        /// PlayFab unique identifier of the user for this leaderboard entry.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Title-specific display name of the user for this leaderboard entry.
        /// </summary>
        public string DisplayName { get; set;}

        /// <summary>
        /// Specific value of the user's statistic.
        /// </summary>
        public int StatValue { get; set;}

        /// <summary>
        /// User's overall position in the leaderboard.
        /// </summary>
        public int Position { get; set;}
    }

    public class PlayerStatisticVersion
    {

        /// <summary>
        /// name of the statistic when the version became active
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// version of the statistic
        /// </summary>
        public uint Version { get; set;}

        /// <summary>
        /// time at which the statistic version was scheduled to become active, based on the configured ResetInterval
        /// </summary>
        public DateTime? ScheduledActivationTime { get; set;}

        /// <summary>
        /// time when the statistic version became active
        /// </summary>
        public DateTime ActivationTime { get; set;}

        /// <summary>
        /// time at which the statistic version was scheduled to become inactive, based on the configured ResetInterval
        /// </summary>
        public DateTime? ScheduledDeactivationTime { get; set;}

        /// <summary>
        /// time when the statistic version became inactive due to statistic version incrementing
        /// </summary>
        public DateTime? DeactivationTime { get; set;}
    }

    public class RedeemCouponRequest
    {

        /// <summary>
        /// Generated coupon code to redeem.
        /// </summary>
        public string CouponCode { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Catalog version of the coupon.
        /// </summary>
        public string CatalogVersion { get; set;}
    }

    public class RedeemCouponResult : PlayFabResultCommon
    {

        /// <summary>
        /// Items granted to the player as a result of redeeming the coupon.
        /// </summary>
        public List<ItemInstance> GrantedItems { get; set;}
    }

    public class RedeemMatchmakerTicketRequest
    {

        /// <summary>
        /// Server authorization ticket passed back from a call to Matchmake or StartGame.
        /// </summary>
        public string Ticket { get; set;}

        /// <summary>
        /// Unique identifier of the Game Server Instance that is asking for validation of the authorization ticket.
        /// </summary>
        public string LobbyId { get; set;}
    }

    public class RedeemMatchmakerTicketResult : PlayFabResultCommon
    {

        /// <summary>
        /// Boolean indicating whether the ticket was validated by the PlayFab service.
        /// </summary>
        public bool TicketIsValid { get; set;}

        /// <summary>
        /// Error value if the ticket was not validated.
        /// </summary>
        public string Error { get; set;}

        /// <summary>
        /// User account information for the user validated.
        /// </summary>
        public UserAccountInfo UserInfo { get; set;}
    }

    public class RemoveSharedGroupMembersRequest
    {

        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId { get; set;}

        /// <summary>
        /// An array of unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public List<string> PlayFabIds { get; set;}
    }

    public class RemoveSharedGroupMembersResult : PlayFabResultCommon
    {
    }

    public class ReportPlayerServerRequest
    {

        /// <summary>
        /// PlayFabId of the reporting player.
        /// </summary>
        public string ReporterId { get; set;}

        /// <summary>
        /// PlayFabId of the reported player.
        /// </summary>
        public string ReporteeId { get; set;}

        /// <summary>
        /// Title player was reported in, optional if report not for specific title.
        /// </summary>
        public string TitleId { get; set;}

        /// <summary>
        /// Optional additional comment by reporting player.
        /// </summary>
        public string Comment { get; set;}
    }

    public class ReportPlayerServerResult : PlayFabResultCommon
    {

        /// <summary>
        /// Indicates whether this action completed successfully.
        /// </summary>
        public bool Updated { get; set;}

        /// <summary>
        /// The number of remaining reports which may be filed today by this reporting player.
        /// </summary>
        public int SubmissionsRemaining { get; set;}
    }

    public class RevokeInventoryItemRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId { get; set;}
    }

    public class RevokeInventoryResult : PlayFabResultCommon
    {
    }

    public class ScriptExecutionError
    {

        /// <summary>
        /// Error code, such as CloudScriptNotFound, JavascriptException, CloudScriptFunctionArgumentSizeExceeded, CloudScriptAPIRequestCountExceeded, CloudScriptAPIRequestError, or CloudScriptHTTPRequestError
        /// </summary>
        public string Error { get; set;}

        /// <summary>
        /// Details about the error
        /// </summary>
        public string Message { get; set;}

        /// <summary>
        /// Point during the execution of the script at which the error occurred, if any
        /// </summary>
        public string StackTrace { get; set;}
    }

    public class SendPushNotificationRequest
    {

        /// <summary>
        /// PlayFabId of the recipient of the push notification.
        /// </summary>
        public string Recipient { get; set;}

        /// <summary>
        /// Text of message to send.
        /// </summary>
        public string Message { get; set;}

        /// <summary>
        /// Subject of message to send (may not be displayed in all platforms.
        /// </summary>
        public string Subject { get; set;}
    }

    public class SendPushNotificationResult : PlayFabResultCommon
    {
    }

    public class SetGameServerInstanceStateRequest
    {

        /// <summary>
        /// Unique identifier of the Game Instance to be updated.
        /// </summary>
        public string LobbyId { get; set;}

        /// <summary>
        /// State to set for the specified game server instance.
        /// </summary>
        public GameInstanceState State { get; set;}
    }

    public class SetGameServerInstanceStateResult : PlayFabResultCommon
    {
    }

    public class SetPublisherDataRequest
    {

        /// <summary>
        /// key we want to set a value on (note, this is additive - will only replace an existing key's value if they are the same name.) Keys are trimmed of whitespace. Keys may not begin with the '!' character.
        /// </summary>
        public string Key { get; set;}

        /// <summary>
        /// new value to set. Set to null to remove a value
        /// </summary>
        public string Value { get; set;}
    }

    public class SetPublisherDataResult : PlayFabResultCommon
    {
    }

    public class SetTitleDataRequest
    {

        /// <summary>
        /// key we want to set a value on (note, this is additive - will only replace an existing key's value if they are the same name.) Keys are trimmed of whitespace. Keys may not begin with the '!' character.
        /// </summary>
        public string Key { get; set;}

        /// <summary>
        /// new value to set. Set to null to remove a value
        /// </summary>
        public string Value { get; set;}
    }

    public class SetTitleDataResult : PlayFabResultCommon
    {
    }

    public class SharedGroupDataRecord
    {

        /// <summary>
        /// Data stored for the specified group data key.
        /// </summary>
        public string Value { get; set;}

        /// <summary>
        /// PlayFabId of the user to last update this value.
        /// </summary>
        public string LastUpdatedBy { get; set;}

        /// <summary>
        /// Timestamp for when this data was last updated.
        /// </summary>
        public DateTime LastUpdated { get; set;}

        /// <summary>
        /// Indicates whether this data can be read by all users (public) or only members of the group (private).
        /// </summary>
        public UserDataPermission? Permission { get; set;}
    }

    public class StatisticNameVersion
    {

        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// the version of the statistic to be returned
        /// </summary>
        public uint Version { get; set;}
    }

    public class StatisticUpdate
    {

        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// for updates to an existing statistic value for a player, the version of the statistic when it was loaded. Null when setting the statistic value for the first time.
        /// </summary>
        public uint? Version { get; set;}

        /// <summary>
        /// statistic value for the player
        /// </summary>
        public int Value { get; set;}
    }

    public class StatisticValue
    {

        /// <summary>
        /// unique name of the statistic
        /// </summary>
        public string StatisticName { get; set;}

        /// <summary>
        /// statistic value for the player
        /// </summary>
        public int Value { get; set;}

        /// <summary>
        /// for updates to an existing statistic value for a player, the version of the statistic when it was loaded
        /// </summary>
        public uint Version { get; set;}
    }

    public class SteamPlayFabIdPair
    {

        /// <summary>
        /// Deprecated: Please use SteamStringId
        /// </summary>
        public ulong SteamId { get; set;}

        /// <summary>
        /// Unique Steam identifier for a user.
        /// </summary>
        public string SteamStringId { get; set;}

        /// <summary>
        /// Unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Steam identifier.
        /// </summary>
        public string PlayFabId { get; set;}
    }

    public class SubtractCharacterVirtualCurrencyRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Name of the virtual currency which is to be decremented.
        /// </summary>
        public string VirtualCurrency { get; set;}

        /// <summary>
        /// Amount to be subtracted from the user balance of the specified virtual currency.
        /// </summary>
        public int Amount { get; set;}
    }

    public class SubtractUserVirtualCurrencyRequest
    {

        /// <summary>
        /// PlayFab unique identifier of the user whose virtual currency balance is to be decreased.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Name of the virtual currency which is to be decremented.
        /// </summary>
        public string VirtualCurrency { get; set;}

        /// <summary>
        /// Amount to be subtracted from the user balance of the specified virtual currency.
        /// </summary>
        public int Amount { get; set;}
    }

    public enum TitleActivationStatus
    {
        None,
        ActivatedTitleKey,
        PendingSteam,
        ActivatedSteam,
        RevokedSteam
    }

    public class TitleNewsItem
    {

        /// <summary>
        /// Date and time when the news items was posted.
        /// </summary>
        public DateTime Timestamp { get; set;}

        /// <summary>
        /// Unique identifier of news item.
        /// </summary>
        public string NewsId { get; set;}

        /// <summary>
        /// Title of the news item.
        /// </summary>
        public string Title { get; set;}

        /// <summary>
        /// News item text.
        /// </summary>
        public string Body { get; set;}
    }

    public class UnlockContainerInstanceRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// ItemInstanceId of the container to unlock.
        /// </summary>
        public string ContainerItemInstanceId { get; set;}

        /// <summary>
        /// ItemInstanceId of the key that will be consumed by unlocking this container.  If the container requires a key, this parameter is required.
        /// </summary>
        public string KeyItemInstanceId { get; set;}

        /// <summary>
        /// Specifies the catalog version that should be used to determine container contents.  If unspecified, uses catalog associated with the item instance.
        /// </summary>
        public string CatalogVersion { get; set;}
    }

    public class UnlockContainerItemRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Catalog ItemId of the container type to unlock.
        /// </summary>
        public string ContainerItemId { get; set;}

        /// <summary>
        /// Specifies the catalog version that should be used to determine container contents.  If unspecified, uses default/primary catalog.
        /// </summary>
        public string CatalogVersion { get; set;}
    }

    public class UnlockContainerItemResult : PlayFabResultCommon
    {

        /// <summary>
        /// Unique instance identifier of the container unlocked.
        /// </summary>
        public string UnlockedItemInstanceId { get; set;}

        /// <summary>
        /// Unique instance identifier of the key used to unlock the container, if applicable.
        /// </summary>
        public string UnlockedWithItemInstanceId { get; set;}

        /// <summary>
        /// Items granted to the player as a result of unlocking the container.
        /// </summary>
        public List<ItemInstance> GrantedItems { get; set;}

        /// <summary>
        /// Virtual currency granted to the player as a result of unlocking the container.
        /// </summary>
        public Dictionary<string,uint> VirtualCurrency { get; set;}
    }

    public class UpdateCharacterDataRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data { get; set;}

        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove { get; set;}

        /// <summary>
        /// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set.
        /// </summary>
        public UserDataPermission? Permission { get; set;}
    }

    public class UpdateCharacterDataResult : PlayFabResultCommon
    {

        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion { get; set;}
    }

    public class UpdateCharacterStatisticsRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Statistics to be updated with the provided values.
        /// </summary>
        public Dictionary<string,int> CharacterStatistics { get; set;}
    }

    public class UpdateCharacterStatisticsResult : PlayFabResultCommon
    {
    }

    public class UpdatePlayerStatisticsRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Statistics to be updated with the provided values
        /// </summary>
        public List<StatisticUpdate> Statistics { get; set;}
    }

    public class UpdatePlayerStatisticsResult : PlayFabResultCommon
    {
    }

    public class UpdateSharedGroupDataRequest
    {

        /// <summary>
        /// Unique identifier for the shared group.
        /// </summary>
        public string SharedGroupId { get; set;}

        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data { get; set;}

        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove { get; set;}

        /// <summary>
        /// Permission to be applied to all user data keys in this request.
        /// </summary>
        public UserDataPermission? Permission { get; set;}
    }

    public class UpdateSharedGroupDataResult : PlayFabResultCommon
    {
    }

    public class UpdateUserDataRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data { get; set;}

        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove { get; set;}

        /// <summary>
        /// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set.
        /// </summary>
        public UserDataPermission? Permission { get; set;}
    }

    public class UpdateUserDataResult : PlayFabResultCommon
    {

        /// <summary>
        /// Indicates the current version of the data that has been set. This is incremented with every set call for that type of data (read-only, internal, etc). This version can be provided in Get calls to find updated data.
        /// </summary>
        public uint DataVersion { get; set;}
    }

    public class UpdateUserInternalDataRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data { get; set;}

        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove { get; set;}
    }

    public class UpdateUserInventoryItemDataRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned instance identifier of the item
        /// </summary>
        public string ItemInstanceId { get; set;}

        /// <summary>
        /// Key-value pairs to be written to the custom data. Note that keys are trimmed of whitespace, are limited in size, and may not begin with a '!' character.
        /// </summary>
        public Dictionary<string,string> Data { get; set;}

        /// <summary>
        /// Optional list of Data-keys to remove from UserData.  Some SDKs cannot insert null-values into Data due to language constraints.  Use this to delete the keys directly.
        /// </summary>
        public List<string> KeysToRemove { get; set;}
    }

    public class UpdateUserStatisticsRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Statistics to be updated with the provided values.
        /// </summary>
        public Dictionary<string,int> UserStatistics { get; set;}
    }

    public class UpdateUserStatisticsResult : PlayFabResultCommon
    {
    }

    public class UserAccountInfo
    {

        /// <summary>
        /// Unique identifier for the user account
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Timestamp indicating when the user account was created
        /// </summary>
        public DateTime Created { get; set;}

        /// <summary>
        /// User account name in the PlayFab service
        /// </summary>
        public string Username { get; set;}

        /// <summary>
        /// Title-specific information for the user account
        /// </summary>
        public UserTitleInfo TitleInfo { get; set;}

        /// <summary>
        /// Personal information for the user which is considered more sensitive
        /// </summary>
        public UserPrivateAccountInfo PrivateInfo { get; set;}

        /// <summary>
        /// User Facebook information, if a Facebook account has been linked
        /// </summary>
        public UserFacebookInfo FacebookInfo { get; set;}

        /// <summary>
        /// User Steam information, if a Steam account has been linked
        /// </summary>
        public UserSteamInfo SteamInfo { get; set;}

        /// <summary>
        /// User Gamecenter information, if a Gamecenter account has been linked
        /// </summary>
        public UserGameCenterInfo GameCenterInfo { get; set;}

        /// <summary>
        /// User iOS device information, if an iOS device has been linked
        /// </summary>
        public UserIosDeviceInfo IosDeviceInfo { get; set;}

        /// <summary>
        /// User Android device information, if an Android device has been linked
        /// </summary>
        public UserAndroidDeviceInfo AndroidDeviceInfo { get; set;}

        /// <summary>
        /// User Kongregate account information, if a Kongregate account has been linked
        /// </summary>
        public UserKongregateInfo KongregateInfo { get; set;}

        /// <summary>
        /// User PSN account information, if a PSN account has been linked
        /// </summary>
        public UserPsnInfo PsnInfo { get; set;}

        /// <summary>
        /// User Google account information, if a Google account has been linked
        /// </summary>
        public UserGoogleInfo GoogleInfo { get; set;}

        /// <summary>
        /// User XBox account information, if a XBox account has been linked
        /// </summary>
        public UserXboxInfo XboxInfo { get; set;}

        /// <summary>
        /// Custom ID information, if a custom ID has been assigned
        /// </summary>
        public UserCustomIdInfo CustomIdInfo { get; set;}
    }

    public class UserAndroidDeviceInfo
    {

        /// <summary>
        /// Android device ID
        /// </summary>
        public string AndroidDeviceId { get; set;}
    }

    public class UserCustomIdInfo
    {

        /// <summary>
        /// Custom ID
        /// </summary>
        public string CustomId { get; set;}
    }

    public enum UserDataPermission
    {
        Private,
        Public
    }

    public class UserDataRecord
    {

        /// <summary>
        /// User-supplied data for this user data key.
        /// </summary>
        public string Value { get; set;}

        /// <summary>
        /// Timestamp indicating when this data was last updated.
        /// </summary>
        public DateTime LastUpdated { get; set;}

        /// <summary>
        /// Permissions on this data key.
        /// </summary>
        public UserDataPermission? Permission { get; set;}
    }

    public class UserFacebookInfo
    {

        /// <summary>
        /// Facebook identifier
        /// </summary>
        public string FacebookId { get; set;}

        /// <summary>
        /// Facebook full name
        /// </summary>
        public string FullName { get; set;}
    }

    public class UserGameCenterInfo
    {

        /// <summary>
        /// Gamecenter identifier
        /// </summary>
        public string GameCenterId { get; set;}
    }

    public class UserGoogleInfo
    {

        /// <summary>
        /// Google ID
        /// </summary>
        public string GoogleId { get; set;}

        /// <summary>
        /// Email address of the Google account
        /// </summary>
        public string GoogleEmail { get; set;}

        /// <summary>
        /// Locale of the Google account
        /// </summary>
        public string GoogleLocale { get; set;}

        /// <summary>
        /// Gender information of the Google account
        /// </summary>
        public string GoogleGender { get; set;}
    }

    public class UserIosDeviceInfo
    {

        /// <summary>
        /// iOS device ID
        /// </summary>
        public string IosDeviceId { get; set;}
    }

    public class UserKongregateInfo
    {

        /// <summary>
        /// Kongregate ID
        /// </summary>
        public string KongregateId { get; set;}

        /// <summary>
        /// Kongregate Username
        /// </summary>
        public string KongregateName { get; set;}
    }

    public enum UserOrigination
    {
        Organic,
        Steam,
        Google,
        Amazon,
        Facebook,
        Kongregate,
        GamersFirst,
        Unknown,
        IOS,
        LoadTest,
        Android,
        PSN,
        GameCenter,
        CustomId,
        XboxLive,
        Parse
    }

    public class UserPrivateAccountInfo
    {

        /// <summary>
        /// user email address
        /// </summary>
        public string Email { get; set;}
    }

    public class UserPsnInfo
    {

        /// <summary>
        /// PSN account ID
        /// </summary>
        public string PsnAccountId { get; set;}

        /// <summary>
        /// PSN online ID
        /// </summary>
        public string PsnOnlineId { get; set;}
    }

    public class UserSteamInfo
    {

        /// <summary>
        /// Steam identifier
        /// </summary>
        public string SteamId { get; set;}

        /// <summary>
        /// the country in which the player resides, from Steam data
        /// </summary>
        public string SteamCountry { get; set;}

        /// <summary>
        /// currency type set in the user Steam account
        /// </summary>
        public Currency? SteamCurrency { get; set;}

        /// <summary>
        /// what stage of game ownership the user is listed as being in, from Steam
        /// </summary>
        public TitleActivationStatus? SteamActivationStatus { get; set;}
    }

    public class UserTitleInfo
    {

        /// <summary>
        /// name of the user, as it is displayed in-game
        /// </summary>
        public string DisplayName { get; set;}

        /// <summary>
        /// source by which the user first joined the game, if known
        /// </summary>
        public UserOrigination? Origination { get; set;}

        /// <summary>
        /// timestamp indicating when the user was first associated with this game (this can differ significantly from when the user first registered with PlayFab)
        /// </summary>
        public DateTime Created { get; set;}

        /// <summary>
        /// timestamp for the last user login for this title
        /// </summary>
        public DateTime? LastLogin { get; set;}

        /// <summary>
        /// timestamp indicating when the user first signed into this game (this can differ from the Created timestamp, as other events, such as issuing a beta key to the user, can associate the title to the user)
        /// </summary>
        public DateTime? FirstLogin { get; set;}

        /// <summary>
        /// boolean indicating whether or not the user is currently banned for a title
        /// </summary>
        public bool? isBanned { get; set;}
    }

    public class UserXboxInfo
    {

        /// <summary>
        /// XBox user ID
        /// </summary>
        public string XboxUserId { get; set;}
    }

    public class VirtualCurrencyRechargeTime
    {

        /// <summary>
        /// Time remaining (in seconds) before the next recharge increment of the virtual currency.
        /// </summary>
        public int SecondsToRecharge { get; set;}

        /// <summary>
        /// Server timestamp in UTC indicating the next time the virtual currency will be incremented.
        /// </summary>
        public DateTime RechargeTime { get; set;}

        /// <summary>
        /// Maximum value to which the regenerating currency will automatically increment. Note that it can exceed this value through use of the AddUserVirtualCurrency API call. However, it will not regenerate automatically until it has fallen below this value.
        /// </summary>
        public int RechargeMax { get; set;}
    }

    public class WriteEventResponse : PlayFabResultCommon
    {

        /// <summary>
        /// The ID of the event as it was written to PlayStream. This is an alphanumeric GUID.
        /// </summary>
        public string EventId { get; set;}
    }

    public class WriteServerCharacterEventRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// Unique PlayFab assigned ID for a specific character owned by a user
        /// </summary>
        public string CharacterId { get; set;}

        /// <summary>
        /// The name of this event. This field is alphanumeric and at most 64 characters long. It is internally namespaced down onto the calling title. Best practices are to name in subject_verb_object format (player_logged_in).
        /// </summary>
        public string EventName { get; set;}

        /// <summary>
        /// The time (in UTC) associated with this event. If omitted, a timestamp of now in UTC will be applied.
        /// </summary>
        public DateTime? Timestamp { get; set;}

        /// <summary>
        /// Arbitrary json values that represent the custom body of this event.
        /// </summary>
        public Dictionary<string,object> Body { get; set;}
    }

    public class WriteServerPlayerEventRequest
    {

        /// <summary>
        /// Unique PlayFab assigned ID of the user on whom the operation will be performed.
        /// </summary>
        public string PlayFabId { get; set;}

        /// <summary>
        /// The name of this event. This field is alphanumeric and at most 64 characters long. It is internally namespaced down onto the calling title. Best practices are to name in subject_verb_object format (player_logged_in).
        /// </summary>
        public string EventName { get; set;}

        /// <summary>
        /// The time (in UTC) associated with this event. If omitted, a timestamp of 'now' in UTC will be applied.
        /// </summary>
        public DateTime? Timestamp { get; set;}

        /// <summary>
        /// Arbitrary json values that represent the custom body of this event.
        /// </summary>
        public Dictionary<string,object> Body { get; set;}
    }

    public class WriteTitleEventRequest
    {

        /// <summary>
        /// The name of this event. This field is alphanumeric and at most 64 characters long. It is internally namespaced down onto the calling title. Best practices are to name in subject_verb_object format (player_logged_in).
        /// </summary>
        public string EventName { get; set;}

        /// <summary>
        /// The time (in UTC) associated with this event. If omitted, a timestamp of now in UTC will be applied.
        /// </summary>
        public DateTime? Timestamp { get; set;}

        /// <summary>
        /// Arbitrary json values that represent the custom body of this event.
        /// </summary>
        public Dictionary<string,object> Body { get; set;}
    }
}
