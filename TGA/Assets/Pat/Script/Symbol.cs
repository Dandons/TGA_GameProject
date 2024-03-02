using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

[CreateAssetMenu(menuName =("Symbols"))]
public class Symbol : ScriptableObject
{
    public enum SymbolType{
        MainSymbol,
        SubSymbol
    }
    public SymbolType symbolType;
    [SerializeField] float atkSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float rollSpeed;
    [SerializeField] float dmgAmplifier;
    [SerializeField] float atk;
    [SerializeField] float def;
    [SerializeField] float sta;
    [HideInInspector] int level = 0;
    private int maxLevel;
    public Sprite sprite;
    public Skill uniqueSkill;
    public void ActiveUnique(){}
    public void UpLevel(){
        level +=1;
    }
}
