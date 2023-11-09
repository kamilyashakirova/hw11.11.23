using System;
class Song
{
    string name;
    string author;
    Song prev;
    public Song(string name, string author)
    {
        this.name = name;
        this.author = author;
        prev = null;
    }
    public Song()
    {
        name = "";
        author = "";
        prev = null;
    }
    public Song(string name, string author, Song prev)
    {
        this.name = name;
        this.author = author;
        this.prev = prev;
    }

    public void PrintInfo()
    {
        Console.WriteLine("название: {0}",Title());
        Console.WriteLine("автор: {0}", author);
        Console.WriteLine();
    }

    public string Title()
    {
        return name + " by " + author;
    }

    public override bool Equals(object obj)
    {
        Song tm = obj as Song;
        if (tm == null)
        {
            return false;
        }
        return name == tm.name && author == tm.author;
    }
}
