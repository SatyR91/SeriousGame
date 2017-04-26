using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class DailyEventsController : MonoBehaviour {

    List<DailyEvent> dailyEvents;
    public FamilyMember Dad;
    public FamilyMember Mom;
    public FamilyMember Teen;
    public FamilyMember Kid;

	// Use this for initialization
	void Awake () {
        dailyEvents = new List<DailyEvent>();

        List<FamilyMember> emptyTargets = new List<FamilyMember>();
        // List of all Events
        dailyEvents.Add(new ThrowParty(new List<FamilyMember> { Teen }));
        dailyEvents.Add(new TeenFriendBirthday(new List<FamilyMember> { Teen }));
        dailyEvents.Add(new GoToCinema(new List<FamilyMember> { Mom, Dad }));
        dailyEvents.Add(new BossDinner(new List<FamilyMember> { Dad }));
        dailyEvents.Add(new GoToBowling(new List<FamilyMember> { Mom, Dad, Teen, Kid}));
        dailyEvents.Add(new TripToDisneyLand(new List<FamilyMember> { Mom, Dad, Teen, Kid }));
        dailyEvents.Add(new InviteFriends(new List<FamilyMember> { Mom, Dad, Teen, Kid }));
        dailyEvents.Add(new InviteSarah(new List<FamilyMember> { Kid }));
        dailyEvents.Add(new InviteKidFriends(new List<FamilyMember> { Kid }));

        // Sort list by rarity
        dailyEvents.Sort(SortByRarity);
    }

    static int SortByRarity(DailyEvent e1, DailyEvent e2) {
        return e1.rarity.CompareTo(e2.rarity);
    }

    public DailyEvent SelectRandomEvent(int rarity) {
        List<DailyEvent> rarityEvents = dailyEvents.FindAll(x => x.rarity == rarity);
        return rarityEvents[Random.Range(0, rarityEvents.Count)];
    }

    public int RandomRarity()
    {
        float val = Random.Range(0f, 1f);
        if (val > 0.95f)
        {
            return 2;
        }
        else if (val > 0.7f)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
