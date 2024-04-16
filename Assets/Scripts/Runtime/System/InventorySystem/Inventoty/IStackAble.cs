

using System;

public interface IStackAble 
{
    public int MaxStack { get; }
    public int CurrentStack { get; set; }

    public void DecreseStacK(int quantity);
    public int AddStack(int quantity);
  

}
