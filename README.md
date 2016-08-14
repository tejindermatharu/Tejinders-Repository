# Tejinders-Repository

<h2> Build </h2>

<ul>
  <li>Set start up project to CashMachine.Console</li>
  <li>Currently defualted to Algorithm 1</li>
  <li>To change this, go to the ConsoleModule class and comment out the binding for LeastItemsCalculator and uncomment the one for
      MaxPerItemCalculator. Re-build and re-run.</li>
</ul>

<h2> Tests </h2>

There are unit tests and Integrations tests projects, please run them to see the passing tests. With more time, these would be more 
comprehensive i.e edge cases and more tests more more scenarios (eg failure tests). What I have done is simply illustrate that there are some
core test suites and that the system has been built so that it is easily testable.

<h2> Areas for improvement </h2>

With more time and attention here are some areas of improvement:

<ul>
  <li>A proper repository and persistence store, not a fake one that have used</li>
  <li>The system currently does not factor in multi user usage and no transactional behaviour is used</li>
  <li>Some proper exception handling and defensive coding</li>
</ul>

