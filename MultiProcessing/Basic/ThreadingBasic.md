<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
</head>
<body>
<div>
<h3>Threading Basic</h3>
<ul>
  <li>Once thread ended, a thread cannot restart.</li>
  <li>Thread does not return value even exception</li>
  <li>Thread take 1 MB memory by default</li>
  <li>The Clr assign each thread own memeory stack to local variable kept separate </li>
  <li>Shared data is the primary cause of complexity and obscure errors in multithreading</li>
  <li>Multithreading is managed internally by a thread scheduler.</li>
  <li>Number of thread created on single machine is depend upon the machine configuration</li>
  <li>A thread scheduler ensures all active threads are allocated appropriate execution time.</li>
  <li>It’s almost certain there will still be some time-slicing, because of the operating system’s need to service its own threads—as well as those of other applications.</li>
  <li>Each thread has a Name property that you can set for the benefit of debugging</li>
<ul>
<h3>Foreground and Background Thread:</h3>
By default, threads you create explicitly are foreground threads. Foreground threads keep the application alive for as long as any one of them is running, whereas background threads do not. Once all foreground threads finish, 
  the application ends, and any background threads still running abruptly terminate.
	<h4>Background:</h4>
    <ul>
	    <li> Background thread is also called Daemon Thread.</li>
	    <li> These threads are less priority threads.</li>
	    <li> CLR will not wait for these threads to finish their execution.</li>
	    <li> These threads are used to perform some background tasks like garbage collection and house-keeping tasks.</li>
	    <li> Main thread also created as Background thread.</li>
    </ul>
</div>
</body>
</html>
