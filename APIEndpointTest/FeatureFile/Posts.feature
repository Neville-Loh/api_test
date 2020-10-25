Feature: Posts
	In order to pefrom CRUD operations on the project
	As a client of the Web Api
	I want to be able to Create, Update, Delete, and Read posts.

@mytag
	Scenario Outline: Add Post
	Given I create a new post with (<userId>,'<title>','<body>',<id>)
	Then the system should return <StatusCode>

Examples:
	| userId | title    | body     | id | StatusCode |
	| 1      | ajksdajf | asjdklfj | 2  | 201        |


@mytag-2
	Scenario Outline: Get Post
	When I request to view post with id <id>
	Then system should return <StatusCode>
	And system should reutrn post header (<userId>,'<title>','<body>',<id>)

Examples: 
	| userId | title			 | body									   | StatusCode | id  |
	| 1		 | Outstanding title | This is a long discription of the body  | 200		|  1  |





