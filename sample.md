
IfOrDictionary
====
SADFSAFSAFSDAF

|               | FromDict | FromIfElse |
| ------------- | -------------      | ------------- |
| 10000  | 2.992ms  | 0.9967ms  |
| 1000000  | 46.8733ms  | 66.8365ms  |
| 10000000  | 395.9418ms  | 529.585ms  |

Sourcecode
----
__FromDict__
```cs
            foreach (var i in input)
            {
                string output = null;
                dict.TryGetValue(i, out output);
            }
        }

```
__FromIfElse__
```cs
            foreach (var i in input)
            {
                string output = null;

                if (i == "void") output = "void";
                else if (i == "int") output = "int";
                else if (i == "char") output = "char";
                else if (i == "byte") output = "byte";
                else if (i == "sbyte") output = "sbyte";
                else if (i == "bool") output = "bool";
                else if (i == "short") output = "short";
                else if (i == "ushort") output = "ushort";
                else if (i == "string") output = "string";
                else if (i == "float") output = "float";
                else if (i == "double") output = "double";
                else if (i == "decimal") output = "decimal";
                else if (i == "uint") output = "uint";
                else if (i == "long") output = "long";
                else if (i == "ulong") output = "ulong";
                else if (i == "object") output = "object";
            }
        }

```

IL Comparision
----

|               | FromDict | FromIfElse |
| ------------- | -------------      | ------------- |
| Codesize  | 37b  | 461b  |

__FromDict__
```MSIL
IL_0000: nop
IL_0001: nop
IL_0002: ldarg.1
IL_0003: stloc.0
IL_0004: ldc.i4.0
IL_0005: stloc.1
IL_0006: br.s IL_001e
IL_0008: ldloc.0
IL_0009: ldloc.1
IL_000a: ldelem.ref
IL_000b: stloc.2
IL_000c: nop
IL_000d: ldnull
IL_000e: stloc.3
IL_000f: ldarg.2
IL_0010: ldloc.2
IL_0011: ldloca.s V_3
IL_0013: callvirt System.Boolean System.Collections.Generic.Dictionary`2<System.String,System.String>::TryGetValue(!0,!1&)
IL_0018: pop
IL_0019: nop
IL_001a: ldloc.1
IL_001b: ldc.i4.1
IL_001c: add
IL_001d: stloc.1
IL_001e: ldloc.1
IL_001f: ldloc.0
IL_0020: ldlen
IL_0021: conv.i4
IL_0022: blt.s IL_0008
IL_0024: ret

```
__FromIfElse__
```MSIL
IL_0000: nop
IL_0001: nop
IL_0002: ldarg.1
IL_0003: stloc.0
IL_0004: ldc.i4.0
IL_0005: stloc.1
IL_0006: br IL_01c3
IL_000b: ldloc.0
IL_000c: ldloc.1
IL_000d: ldelem.ref
IL_000e: stloc.2
IL_000f: nop
IL_0010: ldnull
IL_0011: stloc.3
IL_0012: ldloc.2
IL_0013: ldstr "void"
IL_0018: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_001d: stloc.s V_4
IL_001f: ldloc.s V_4
IL_0021: brfalse.s IL_002e
IL_0023: ldstr "void"
IL_0028: stloc.3
IL_0029: br IL_01be
IL_002e: ldloc.2
IL_002f: ldstr "int"
IL_0034: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_0039: stloc.s V_5
IL_003b: ldloc.s V_5
IL_003d: brfalse.s IL_004a
IL_003f: ldstr "int"
IL_0044: stloc.3
IL_0045: br IL_01be
IL_004a: ldloc.2
IL_004b: ldstr "char"
IL_0050: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_0055: stloc.s V_6
IL_0057: ldloc.s V_6
IL_0059: brfalse.s IL_0066
IL_005b: ldstr "char"
IL_0060: stloc.3
IL_0061: br IL_01be
IL_0066: ldloc.2
IL_0067: ldstr "byte"
IL_006c: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_0071: stloc.s V_7
IL_0073: ldloc.s V_7
IL_0075: brfalse.s IL_0082
IL_0077: ldstr "byte"
IL_007c: stloc.3
IL_007d: br IL_01be
IL_0082: ldloc.2
IL_0083: ldstr "sbyte"
IL_0088: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_008d: stloc.s V_8
IL_008f: ldloc.s V_8
IL_0091: brfalse.s IL_009e
IL_0093: ldstr "sbyte"
IL_0098: stloc.3
IL_0099: br IL_01be
IL_009e: ldloc.2
IL_009f: ldstr "bool"
IL_00a4: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_00a9: stloc.s V_9
IL_00ab: ldloc.s V_9
IL_00ad: brfalse.s IL_00ba
IL_00af: ldstr "bool"
IL_00b4: stloc.3
IL_00b5: br IL_01be
IL_00ba: ldloc.2
IL_00bb: ldstr "short"
IL_00c0: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_00c5: stloc.s V_10
IL_00c7: ldloc.s V_10
IL_00c9: brfalse.s IL_00d6
IL_00cb: ldstr "short"
IL_00d0: stloc.3
IL_00d1: br IL_01be
IL_00d6: ldloc.2
IL_00d7: ldstr "ushort"
IL_00dc: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_00e1: stloc.s V_11
IL_00e3: ldloc.s V_11
IL_00e5: brfalse.s IL_00f2
IL_00e7: ldstr "ushort"
IL_00ec: stloc.3
IL_00ed: br IL_01be
IL_00f2: ldloc.2
IL_00f3: ldstr "string"
IL_00f8: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_00fd: stloc.s V_12
IL_00ff: ldloc.s V_12
IL_0101: brfalse.s IL_010e
IL_0103: ldstr "string"
IL_0108: stloc.3
IL_0109: br IL_01be
IL_010e: ldloc.2
IL_010f: ldstr "float"
IL_0114: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_0119: stloc.s V_13
IL_011b: ldloc.s V_13
IL_011d: brfalse.s IL_012a
IL_011f: ldstr "float"
IL_0124: stloc.3
IL_0125: br IL_01be
IL_012a: ldloc.2
IL_012b: ldstr "double"
IL_0130: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_0135: stloc.s V_14
IL_0137: ldloc.s V_14
IL_0139: brfalse.s IL_0143
IL_013b: ldstr "double"
IL_0140: stloc.3
IL_0141: br.s IL_01be
IL_0143: ldloc.2
IL_0144: ldstr "decimal"
IL_0149: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_014e: stloc.s V_15
IL_0150: ldloc.s V_15
IL_0152: brfalse.s IL_015c
IL_0154: ldstr "decimal"
IL_0159: stloc.3
IL_015a: br.s IL_01be
IL_015c: ldloc.2
IL_015d: ldstr "uint"
IL_0162: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_0167: stloc.s V_16
IL_0169: ldloc.s V_16
IL_016b: brfalse.s IL_0175
IL_016d: ldstr "uint"
IL_0172: stloc.3
IL_0173: br.s IL_01be
IL_0175: ldloc.2
IL_0176: ldstr "long"
IL_017b: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_0180: stloc.s V_17
IL_0182: ldloc.s V_17
IL_0184: brfalse.s IL_018e
IL_0186: ldstr "long"
IL_018b: stloc.3
IL_018c: br.s IL_01be
IL_018e: ldloc.2
IL_018f: ldstr "ulong"
IL_0194: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_0199: stloc.s V_18
IL_019b: ldloc.s V_18
IL_019d: brfalse.s IL_01a7
IL_019f: ldstr "ulong"
IL_01a4: stloc.3
IL_01a5: br.s IL_01be
IL_01a7: ldloc.2
IL_01a8: ldstr "object"
IL_01ad: call System.Boolean System.String::op_Equality(System.String,System.String)
IL_01b2: stloc.s V_19
IL_01b4: ldloc.s V_19
IL_01b6: brfalse.s IL_01be
IL_01b8: ldstr "object"
IL_01bd: stloc.3
IL_01be: nop
IL_01bf: ldloc.1
IL_01c0: ldc.i4.1
IL_01c1: add
IL_01c2: stloc.1
IL_01c3: ldloc.1
IL_01c4: ldloc.0
IL_01c5: ldlen
IL_01c6: conv.i4
IL_01c7: blt IL_000b
IL_01cc: ret

```
