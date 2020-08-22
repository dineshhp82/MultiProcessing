<html>
<h3>Threading Basic</h3>
<ul>
  <li>Once thread ended, a thread cannot restart.</li>
  <li>Thread does not return value even exception</li>
  <li>Thread take 1 MB memory by default</li>
  <li>The Clr assign each thread own memeory stack to local variable kept separate <li>
  <li>Shared data is the primary cause of complexity and obscure errors in multithreading<li>
  <li>Multithreading is managed internally by a thread scheduler.</li>
  <li>Number of thread created on single machine is depend upon the machine configuration</li>
  <li>A thread scheduler ensures all active threads are allocated appropriate execution time.</li>
  <li>It’s almost certain there will still be some time-slicing, because of the operating system’s need to service its own threads—as well as those of other applications.</li>
  <li>Each thread has a Name property that you can set for the benefit of debugging</li>
<ul>
</html>