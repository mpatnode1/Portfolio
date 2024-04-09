using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedWord : MonoBehaviour
{
    string[] wordList = new string[]{ "Beach", "Diamond", "Salmon", "Backpack", "Stinky", "Donkey", "Bouncer", "Harpoon", "Headline", "Collection", "Waterfall", "Gorilla", "Duckling", "Zucchini", "Shadow", "Jacuzzi", "Mozarella", "Lantern", "Outhouse", "Nuclear", "Horrify", "Serenity", "Staircase", "Xerox", "Opulence", "Retrospect", "Maximum", "Textual", "Agents", "Eyebrow", "Inject", "Ground", "Decade", "Jewelry", "Excess", "Movement", "Highlight", "Justice", "Theorist", "Symptom", "Canister", "Decisive", "Hilarious", "Presentation", "Integrity", "Eternal", "Romantic", "Plaintiff", "Fixture", "Criticism", "Urgency", "Habitant", "Emotion", "Workshop", "Faithful", "Aquarium", "Kinship", "Glacier", "Version", "Guideline", "Brilliance", "Quarrel", "Crisis", "Organize", "Referee", "Summit", "Horizon", "Physics", "Composer", "Fascinate", "Courage", "Exultant", "Optical", "Enrichment", "Medieval", "Gravitate", "Opposite", "Eradicate", "Trademark", "Disembark", "Keynote", "Pastry", "Excavation", "Federal", "Receipt", "Baseball", "Impede", "Theory", "Wooden", "Corrsepon", "Grandiose", "Cobweb", "Savory", "Ladybug", "Suppose", "Forsake", "Science", "Righteous", "Flagrant", "Breakfast", "Melodic", "Changeable", "Inspect", "Loutish", "Spiritual", "Sabotage", "Disturbance", "Statement", "Calculate", "Impossible", "Desirable", "Evanescent", "Tiresome", "Birthday", "Authority", "Callous", "Previous", "Creature", "Identify", "Friction", "Construe", "Coordinate", "Sidewalk", "Approval", "Cooperate", "Restrain", "Chemical", "Quarter", "Hesitant", "Library", "Capable", "Insurance", "Integrate", "Subscribe", "Cabbage", "Discreet", "Obedient", "Question", "Building", "Hospital", "Irritate", "Multiply", "Glance", "Defect", "Toothpaste", "Develop", "Shaggy", "Diminish", "Bulbous", "Applaud" };
    public string SelectWord()
    {
        string selectedWord = wordList[UnityEngine.Random.Range(0, wordList.Length)];
        return selectedWord;
    }
}
