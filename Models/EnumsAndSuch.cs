namespace OrthodoxPrayerBlazorSite2.Models;


public enum MealKindEnum { Breakfast, Lunch, Dinner, }

public enum BeforeAfterKindEnum { Before, After, }

public enum PsalmTimeOfDayKindEnum
{
    Midnight,
    Matins,
    Hour1,
    Hour3,
    Hour6,
    Hour9,
    Vespers,
    LittleCompline
}

public enum MainPrayerChoiceKind
{
    None,
    Meal,
    MorningPrayer,
    EveningPrayer,
}

public enum EnglishKindEnum
{
    Contemporary,
    Old,
}

public enum HeadingKindEnum
{
    None,
    MainHeading,
    Heading,
    SubHeading,
    SubHeading2,
}
