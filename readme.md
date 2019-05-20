SmallBench
====

[Sample report](sample.md)

```cs
[TestDescription("")]
[TestIteration(new int[] { 100, 1000, 10000 })]
public class SampleCase : Testcase {
	
	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	public void SumWithoutBoxing() {
	
	}
	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	public void SumWithBoxing() {
	
	}
}
```
