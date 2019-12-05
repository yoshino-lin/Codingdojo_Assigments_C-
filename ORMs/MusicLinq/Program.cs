using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = MusicStore.GetData().AllArtists;
            List<Group> Groups = MusicStore.GetData().AllGroups;

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            Artist Mount_Vernon = Artists.FirstOrDefault(prod => prod.Hometown == "Mount Vernon");
            Console.WriteLine($"Name: {Mount_Vernon.ArtistName}");
            Console.WriteLine($"Age: {Mount_Vernon.Age}");

            //Who is the youngest artist in our collection of artists?
            Artist youngest_artist = Artists
                .OrderBy(prod => prod.Age)
                .First();
            Console.WriteLine($"Name: {youngest_artist.ArtistName}");
            Console.WriteLine($"Age: {youngest_artist.Age}");
            
            //Display all artists with 'William' somewhere in their real name
            IEnumerable<Artist> artists_William = Artists.Where(prod => prod.RealName.Contains("William"));
            
            foreach(Artist Artist_name in artists_William){
                Console.WriteLine($"Name: {Artist_name.RealName}");
            }
            
            //Display all groups with names less than 8 characters in length.
            IEnumerable<Group> name_short = Groups.Where(prod => prod.GroupName.Length < 8);
            foreach(Group Artist_name in name_short){
                Console.WriteLine($"Groups Name: {Artist_name.GroupName}");
            }

            //Display the 3 oldest artist from Atlanta
            Artist[] oldest_artist_array = Artists
                .Where(prod => prod.Hometown == "Atlanta")
                .OrderByDescending(prod => prod.Age)
                .Take(3)
                .ToArray();
            Console.WriteLine($"Name: {oldest_artist_array[0].ArtistName}");
            Console.WriteLine($"Age: {oldest_artist_array[0].Age}");
            Console.WriteLine($"Name: {oldest_artist_array[1].ArtistName}");
            Console.WriteLine($"Age: {oldest_artist_array[1].Age}");
            Console.WriteLine($"Name: {oldest_artist_array[2].ArtistName}");
            Console.WriteLine($"Age: {oldest_artist_array[2].Age}");
            //Console.WriteLine($"Name: {oldest_artist_array[3].ArtistName}");

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            IEnumerable<Artist> author_not_NewYork = Artists.Where(prod => prod.Hometown!="New York City");
            List<int> Group_ok_id = new List<int>();
            foreach(Artist Artist_name in author_not_NewYork){
                if(!Group_ok_id.Contains((int)Artist_name.GroupId)){
                    Group_ok_id.Add(Artist_name.GroupId);
                }
            }
            Group[] all_group_to_dispaly = Groups
                .Where(prod => Group_ok_id.Contains(prod.Id))
                .ToArray();
            foreach(Group Group_name in all_group_to_dispaly){
                Console.WriteLine($"Group Name: {Group_name.GroupName}");
            }


            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            Group WuTangClan = Groups.FirstOrDefault(prod => prod.GroupName == "Wu-Tang Clan");
            List<Artist> WuTangClanArtists = WuTangClan.Members
                .ToList();
	        Console.WriteLine(WuTangClanArtists.Count);
            foreach(Artist Artist_name in WuTangClanArtists){
                Console.WriteLine($"Wu-Tang Clan Artist Name: {Artist_name.RealName}");
            }
        }
    }
}
