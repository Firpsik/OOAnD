﻿namespace SpaceBattle;

public interface IStrategy
{
    public object Invoke(params object[] args);
}