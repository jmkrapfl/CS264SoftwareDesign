public class Memento
{
    string state;
    // Constructor
    public Memento(string state)
    {
        this.state = state;
    }
    public string getState()
    {
        return this.state;
    }

    public override string ToString()//override toString so it actually prints out what is in it
    {
        return state;
    }
}
