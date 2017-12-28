# MediatrSamples
Samples of Mediatr v4 usage. 
In order to know what Mediatr is please visit https://github.com/jbogard/MediatR

This solution contains two projects:

- An **Asp.Net Core MVC website**, that has a concrete action in a controller that is going to use Mediatr.

    Controller: HomeController

    Action: Index

    So to start the interaction with Mediatr please invoke /home/index

- A **library** that exposes commands, responses, handlers and events.

Once the action is invoked, different interactions with Mediatr will happend:

1. A command, handled by an asynchronous handler, is sent. Response is received
1. A command defined with no response is handled by an asynchronous handler
1. A command, handled by an asynchronous handler with no cancellation token, is sent. Response is received
1. Several handlers are defined for same command. Just one of them is executed.
1. A command is send and then handled by an **synchronous** handler. Response is received
1. An event is sent and is managed by 2 listeners
1. An event is sent and is managed by 2 different listeners: one with no cancellation token and another one thar works in a synchronous way
1. A listener that will handle all sorts of events is defined

In addition, there are some examples os pipeline behaviours usage. They are in following files:

- 9_APipelineBehaviour.cs

    Here we can found 2 different behaviours that allow us to inject code before a command is handled and after it is handled

    In order to see them working please uncomment logs inside the file

    In addition we also try to define a specialized behaviour (for just one concrete command). Unfortunatelly this is not working

- 9_bis_PostProcessor

    Here we can found a postprocessor that allow us to inject code that will be executed after a command is handled

    In order to see them working please uncomment logs inside the file


Behaviours are defined in asp.net core startup class
