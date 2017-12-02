# C#

# Sources
https://www.youtube.com/watch?v=AXUvnk7Jws4

## Native Container
- NativeArray
- NativeList
- NativeSlice (Part of a Data structure)
- NativeHashMap
- Native MultiHashMap (MultiHashTable)
Can only be used by structs to avoid race conditions
Own Container library

## Structs




## Job System
Jobs are always Structs
struct exampleStruct : IJob {

}
Exactly declare [readOnly]
What is Allocator.Temp?
jobHandle jobHandle = job.Schedule();
//starts job
job.Schedule(int Iterations needed,);

jobHandle.complete();

### dependencies
jobs können übergeben werden als dependency, job a muss auf übergebenen job b warten.
Beide werden ausgeführt und job.complete(); beendet auch beide


? AddDependency(job.Schedule, bla,bla);

### optimization
[ComputeJobOptimization(Accuracy.Med, Support.Relaxed]
accuracy -> rounding accracy (degree, foats, etc.)
data oriented
not update each component
put each component in a list (manager) and let the manager update it
[InjectTuples]
 struct : IComponentData
  : JobComponentSystem
use id of objects as int list to access values

split canvas into static and refreshing stuff
deactivate "raycast target" on displayed stuff that never changes/updates
#### Take control of Data
- override base functions enable disable ondestroy?
