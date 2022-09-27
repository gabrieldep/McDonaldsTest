# McDonaldsTest
**RDI/Capgemini tech test**

## Table of Contents

* [Overview](#overview)
* [Documentation](#documentation)
* [License](#license)
* [Support](#support)
* [About](#about)

## Overview

Assuming that I have a restaurant with multiple POS (point-of-sale) instances sending orders that should be routed to specific
areas of a kitchen, I was tasked with writing a piece of software to do a Restaurant Order Routing.
It must comprise a HTTP Server with an endpoint to receive an Order and place it in a queue representing a destination kitchen area.

## Documentation

This solution is composed by 3 projects. 
You have to install RabbitMQ in your machine to test this solution.

The installation instructions are in the [RabbitMQ](https://www.rabbitmq.com/download.html) web page.

### Web Api
This api was developed with Dotnet 6.0 and have only one endpoint. PostOrder.
This endpoint receives an OrderDetails, a client identifier and a KitchenArea. After that, it post it in the correct queueu on RabbitMq server.
#### Request
`POST /thing/`

    curl -i -H 'Token: token' https://localhost:7027/api/Orders/PostOrder
    { "orderDetails": "foo", "clientIdentifier": "foo", "KitchenArea" : 0}
    
### Queue receiver
Console application developed with Dotnet 6.0 that receives the order data for the correct queue.
#### Configs
You can change the queue in the file appsettings.json

### Test project
This project make integration tests with the Endpoint of the first project and the RabbitMQ

## License

* **Licensing for open source projects:**  
  McDonaldsTest is available under the terms of the [GNU Affero General Public License version 3](http://www.gnu.org/licenses/agpl-3.0.html) as published by the Free Software Foundation.

## Support

Pick one of the options that best suits your needs:
* [gabrieldepaula007@gmail.com](mailto:gabrieldepaula007@gmail.com)

## About

McDonaldsTest has been written by [Gabriel de Paula Silva](https://www.linkedin.com/in/gabriel-depaula16/).
