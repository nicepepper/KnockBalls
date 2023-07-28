using System;

[System.Serializable]
 public class PlayerData : IEquatable<PlayerData> , IComparable<PlayerData>
 {
     public static PlayerData Current;
     public string Name { get; set; }
     public int Score { get; set; }

     public PlayerData(string name = "default", int score = 0)
     {
         this.Name = name;
         this.Score = score;
         Current = this;
     }

     public bool Equals(PlayerData other)
     {
         if (other == null)
         {
             return false;
         }
         return (this.Score.Equals(other.Score));
     }

     public int CompareTo(PlayerData other)
     {
         if (other == null)
         {
             return 1;
         }
         else
         {
             return other.Score.CompareTo(this.Score);
         }
     }

     public override int GetHashCode()
     {
         return Score;
     }
 }
 