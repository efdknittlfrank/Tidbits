﻿using System;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace TrickyCSharp
{
  class SimpleContainer<U>
  {
    public SimpleContainer()
    {
    }
  }

  class DeepContainer<T> : SimpleContainer<DeepContainer<DeepContainer<T>>>
  {
    public DeepContainer()
    {
    }
  }

  public class Person : INotifyPropertyChanged
  {
    private int age;
    public string Name { get; set; }
    public int Age
    {
      get { return age; }
      set
      {
        if (value == age) return;
        age = value;
        OnPropertyChanged();
        OnPropertyChanged("CanVoteForJonSkeet");
      }
    }

    public bool IsCitizen { get; set; }


    public bool CanVote
    {
      get { return Age >= 16 ? IsCitizen : false; }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChangedEventHandler handler = PropertyChanged;
      if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
    }

    public void TestMathSkills()
    {
      var root = Complex.Sqrt(new Complex(-4, 0));
      if (root.Real == 2.0)
        Console.WriteLine("Will this line be output?");
      else 
        Console.WriteLine("Or maybe this one?");
    }
  }
}