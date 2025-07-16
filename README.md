# modernizing-legacy
Pseudocode that demonstrates how I would take a problematic legacy pattern and refactor it for better maintainability.

**Exercise description and answers:**
### Imagine you have access to a legacy C# ASP.NET, based on your experience:

**Summarize 2–3 key architectural or technical limitations/challenges:**
- Codebase uses old system architectures, missing layers and separation of concerns.
- Poor system performance due to bad queries, database design, and poorly maintained code.
- Low code coverage, or even missing unit tests and CI/CD process.

**Propose one targeted technical enhancement:**
I'd propose a system performance improvement. First, by reviewing core functionalities well-known for their performance issues (which the maintenance team usually tracks), or by improving logs with Serilog for better traceability, and then identify opportunities for improvement.
In addition, I would also address methods lacking async/await (to prevent thread starvation) and external calls (queries, services, files) performed within loops, which could be replaced by bulk operations.
Tracking tools in the database should be used to identify resource-intensive queries for refactoring and performance improvement. This refactoring could include quick changes, such as reducing the amount of data (columns) retrieved or adding indexes for fields used for filtering, as well as larger changes, such as refactoring the entire query and code logic.

**Future-State Architecture (Conceptual):**
My target architecture would involve the development of a cloud-native application using multiple microservices by breaking down the monolithic application into smaller web RESTful APIs, each responsible for a specific business context.
Communication between services would be done through events in an event-driven architecture, allowing for indirect communication through messages or events. This would promote looser coupling between services, resilience (as messages can be buffered and retried), and scalability based on message load.
Regarding the data model, I would create a new data model for each microservice. This would allow us to reduce coupling between tables from different business contexts, eliminating the possibility of a single point of failure (as each service would have access to its own database), and enabling scalability and reduced bottlenecks (as services would not compete for the same resources).

The development of the APIs would follow the same patterns and implement:

- Clean Architecture to organize the codebase, improving testability with the separation of core business logic from external concerns. Using DDD would strengthen the core of our application and design it to be business-oriented, improving maintainability and future enhancements.
- CQRS would allow us to scale and optimize application performance by separating read/write operations. With the help of the Mediator pattern, we can better implement this and separate query and command operations.
- To access the data layer, we would use an ORM such as Entity Framework in a code-first approach and manage database creation through migrations.
- In terms of code quality, we would start project development with Sonar and code quality metrics (i.e., code coverage) in place to guarantee that the project achieves its goals from day one. We would also ensure that a CI/CD process is in place, using Git for version control and pull request (PR) review.

Last but not least, the decision on how to host these services would come from a cost evaluation. This would allow us to define whether it would be better to use containers and orchestrators such as Kubernetes or to use a Serverless approach.
