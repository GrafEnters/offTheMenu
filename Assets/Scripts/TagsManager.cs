using System.Collections.Generic;
using System.Linq;

public class TagsManager {
    public static List<CardTag> RearrangeTagsAfterCooking( List<CardTag> tags) {
        tags = tags.Distinct().ToList();
        /*if (tags.Contains(CardTag.Vegan)) {
            if (tags.Contains(CardTag.Meaty)) {
                tags.Remove(CardTag.Vegan);
            } 
        } else {
            if (!tags.Contains(CardTag.Meaty)) {
                tags.Add(CardTag.Vegan);
            } 
        }*/

        return tags;
    }
}
