# Project Description

BScHons-Computer Science

Services Computing 

In this project, I showcased my ability to implement a Microservices Architectural style application using 
ASP.Net Core and Docker with Envoy proxy, acting as an API Gateway for all downstream services.

This application can be used as part of a Supply Chain system as it can keep track of how much material is available and which material items need to be procured during Production or Manufacturing. The system has four components as Microservices which are exposed through the API Gateway. Material Inventory component is used to keep track of
all available stock material, and the Procurement Service is used to purchase stock if there is a shortage of supply. There are two other components which are the Databases each microservice communicates with. All the available components are containerized and exposed through a RESTful web service except for the databases.
