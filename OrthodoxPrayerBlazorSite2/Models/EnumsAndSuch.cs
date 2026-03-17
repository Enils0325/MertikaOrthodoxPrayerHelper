namespace OrthodoxPrayerBlazorSite2.Models;


public enum BeforeAfterKindEnum { Before, After, }

public enum PsalmTimeOfDayKindEnum
{
    Morning,
    Evening,
    //Midnight,
    //Matins,
    //Hour1,
    //Hour3,
    //Hour6,
    //Hour9,
    //Vespers,
    //LittleCompline
}

public enum MainPrayerChoiceKind
{
    None,
    Meal,
    MorningPrayer,
    EveningPrayer,
    Other,
}

public enum OtherPrayerChoiceKind
{
    None,
    AfterSickness,
    ForDeparted,
    ForOthersWhoAreSick,
    ForPriests,
    ForSoldiers,
    ForThoseWithDepression,
    FromChildrenForParents,
    FromParentsForChildren,
    FromSinglePersons,
    NiceneCreed,
    OfHusbandAndWife,
    Repentance,
    StrugglingWithAddiction,
    TimeOfSickness,
    TimeOfTrouble,
    ToFindASpouse,
}

public enum HeadingKindEnum
{
    None,
    MainHeading,
    Heading,
    SubHeading,
    SubHeading2,
}

public enum LanguageKindEnum { EnglishModern, EnglishMixed, EnglishOlder, }