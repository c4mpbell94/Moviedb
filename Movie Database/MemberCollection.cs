//CAB301 assessment 1 - 2022
//The implementation of MemberCollection ADT
using System;
using System.Linq;



public class MemberCollection : IMemberCollection
{

    // Fields
    private int capacity;
    private int count;
    private Member[] members; //make sure members are sorted in dictionary order

    // Properties

    // get the capacity of this member colllection 
    // pre-condition: nil
    // post-condition: return the capacity of this member collection and this member collection remains unchanged
    public int Capacity { get { return capacity; } }

    // get the number of members in this member colllection 
    // pre-condition: nil
    // post-condition: return the number of members in this member collection and this member collection remains unchanged
    public int Number { get { return count; } }


    // Constructor - to create an object of member collection 
    // Pre-condition: capacity > 0
    // Post-condition: an object of this member collection class is created

    public MemberCollection(int capacity)
    {
        if (capacity > 0)
        {
            this.capacity = capacity;
            members = new Member[capacity];
            count = 0;
        }
    }

    // check if this member collection is full
    // Pre-condition: nil
    // Post-condition: return ture if this member collection is full; otherwise return false.
    public bool IsFull()
    {
        return count == capacity;
    }

    // check if this member collection is empty
    // Pre-condition: nil
    // Post-condition: return ture if this member collection is empty; otherwise return false.
    public bool IsEmpty()
    {
        return count == 0;
    }

    // Add a new member to this member collection
    // Pre-condition: this member collection is not full
    // Post-condition: a new member is added to the member collection and the members are sorted in ascending order by their full names;
    // No duplicate will be added into this the member collection
    public void Add(IMember member)
    {
        int i = count - 1;
        if (!IsFull())
        {
            while (i >= 0 && members[i].CompareTo(member) > 0)
            {
                members[i + 1] = members[i];
                i--;
            }
            members[i + 1] = (Member)member;
            count++;
        }
        else
            Console.WriteLine("Capacity of MemberCollection is full - did not add" + member);
    }


    // Remove a given member out of this member collection
    // Pre-condition: nil
    // Post-condition: the given member has been removed from this member collection, if the given meber was in the member collection
    public void Delete(IMember aMember)
    {

        if (!IsEmpty() && Search(aMember) != false)
        {
            int j = 0;
            for (int i = 0; i < count - 1; i++)
            {
                if (members[i] == (Member)aMember)
                {
                    members[i] = null;
                    j = i;
                    break;
                }
            }

            for (int i = j; i < count - 1; i++)
            {
                members[i] = members[i + 1];
            }
            count--;
        }
        else
            Console.WriteLine(aMember + " is not removed successfully as it is not in the sorted list!");
    }

    // Search a given member in this member collection 
    // Pre-condition: nil
    // Post-condition: return true if this memeber is in the member collection; return false otherwise; member collection remains unchanged
    public bool Search(IMember member)
    {
        // To be implemented by students in Phase 1
        for (int i = 0; i <= count - 1; i++)
        {
            if (members[i] == member)
                return true;
        }
        return false;
    }

    // Remove all the members in this member collection
    // Pre-condition: nil
    // Post-condition: no member in this member collection 
    public void Clear()
    {
        for (int i = 0; i < count; i++)
        {
            this.members[i] = null;
        }
        count = 0;
    }



    // Return a string containing the information about all the members in this member collection.
    // The information includes last name, first name and contact number in this order
    // Pre-condition: nil
    // Post-condition: a string containing the information about all the members in this member collection is returned
    public string ToString()
    {
        string s = "";
        for (int i = 0; i < count; i++)
            s = s + members[i].ToString() + "\n";
        return s;
    }


    public void Print()
    {
        for (int i = 0; i <= count - 1; i++)
        {
            Console.Write(members[i] + "  ");
        }
        Console.WriteLine();
    }

}

