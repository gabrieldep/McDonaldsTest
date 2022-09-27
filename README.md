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

This solution is composed by 3 solutions. 

### Web Api developed with Dotnet 6.0
This api have only one endpoint that communicates with a RabbitMQ server.
#### Request
`POST /thing/`

    curl -i -H 'Token: token' https://localhost:7027/api/Orders/PostOrder
    { "orderDetails": "foo", "clientIdentifier": "foo", "KitchenArea" : 0}

## License

* **Licensing for open source projects:**  
  McDonaldsTest is available under the terms of the [GNU Affero General Public License version 3](http://www.gnu.org/licenses/agpl-3.0.html) as published by the Free Software Foundation.

## Support

Pick one of the options that best suits your needs:
* [gabrieldepaula007@gmail.com](mailto:gabrieldepaula007@gmail.com)

## About

McDonaldsTest has been written by [Gabriel de Paula Silva](https://www.linkedin.com/in/gabriel-depaula16/).
