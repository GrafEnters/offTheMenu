using System.Collections.Generic;

public class TagsManager {
    public static List<CardTag> RearrangeTagsAfterCooking( List<CardTag> tags) {
        if (tags.Contains(CardTag.Vegan)) {
            if (tags.Contains(CardTag.Meaty)) {
                tags.Remove(CardTag.Vegan);
            } 
        } else {
            if (!tags.Contains(CardTag.Meaty)) {
                tags.Add(CardTag.Vegan);
            } 
        }

        return tags;
    }
}
