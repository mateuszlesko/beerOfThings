# beerOfThings
IoT project backend for themash tun

## The process of mashing beer (brief overview):
The purpose of mashing is to convert the starch contained in the malt grains into sugars. Enzymes contained in malt take care of it, these enzymes are created by heating the brew at appropriate temperatures. Maintaining the set point is important in this process temperature and mixing the decoction. If these two steps are not carried out properly, in the worst case, the broth may burn, making it unfit for consumption.

## Project overview
Thanks to modern digital networks, it is possible to connect hundreds, thousands, millions of devices into one huge ecosystem. In which devices communicate with each other, they exchange data with each other.

These devices monitor the reality that surrounds us. As public use of these devices increases, awareness of the new possibilities increases. The network is being developed more and more and the economic benefits are growing from it. We call this process digital transformation

Digital transformation is the application of digital technology to create the basis for innovation in business and industry. This digital innovation is currently being used in every aspect of human life.

In the spirit of this thought, intelligent devices are implemented in various industries. One of them may be brewing. Devices armed with control mechanisms for various factors in the process of weighing the drink, e.g. in the form of artificial intelligence; they would ensure automatic control and improvement of beer making procedures, which will directly affect the quality of the product

With this in mind, I decided to design a database that would help such a system to oversee the beer mash process.

### Objectives:
1. Development of a system for storing: recipes, optimal temperatures, temperatures received from sensors during the beer mash process,
2. Monitoring and controlling the temperature during the brewing mash process

### Requirements:
The database is intended to support the mash heating temperature control software. For this reason, an appropriate structure should be created to:
* store recipes of particular beers
* store the optimum temperatures for each mash step for a given recipe
* store temperature data received from the sensor
* be able to compare the temperature from the sensor with the optimal temperature in the recipe
* be able to display a given recipe
* be able to display the entire heating process of a given recipe
* be able to display the next stage of heating the mash


## Database design

### Database schema:
![database design.](/thumbnail_beerOfThings.png "database design")

### Tables overview:

#### Temperature
The "Temperature" table stores the following data:
* solution temperature measured by the sensor
* recipe reference
* reference to the beer heating process
* the moment of time for which the measurement was carried out (counting from the moment of starting a given process)
* date of measurement

The table is used to monitor the mashing process. In the future, it can also be used to implement artificial intelligence mechanisms

#### OptimalTemperature
The "OptimalTemperature" table stores the following data:
* temperature id (identification key)
* optimal heating temperature taken from the recipe
* time how long is to last

It contains reference temperature data to be sought

### Category
The "Category" table stores the following data:
* species id (identification key)
* name of the beer type

It can be used to search for recipes by specifying the type of beer

#### Recipe
The Recipe table stores the following data:
* recipe id (identification key)
* recipe name
* category reference

It acts as a dictionary of recipes you can make.

#### Stage
The "Stage" table stores the following data:
* stage id (identification key)
* mashing stage name / number
* additional textual comments regarding the stage
* reference to the optimal temperature (foreign key)

Maintaining data integrity is an important concern with this table. For example: for many recipes, the optimal temperature may be the same, but the holding time may differ.

#### Brewing:
The "Brewing" table stores the following data:
● reference to the recipe (foreign key)
● reference to the heating stage (foreign key)

It serve as the data source where the individual mash steps for
recipes

#### IngridientsList
The Ingredients table will hold the following data:
● reference to the recipe (foreign key)
● link to an ingredient (foreign key)
● amount of a given ingredient
● unit

#### Ingredient
The "Ingredient" table stores the following data:
● component id (identification key)
● ingredient name

### Application overview:
The application is designed to reset the previously presented assumptions

#### Functionalities:
* Role base access to application views, functionalities: (regular user and brewer); brewer has access to edit, add recipes, see ingridients of recipe; regular user has right to see what beer currently is making
* adding complete beer recipe step by step: recipe name, recipe category, multiple ingridients, multiple heating times
* monitoring process:  a step by step guide to heating a given beer
