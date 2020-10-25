Feature: Posts
	In order to pefrom CRUD operations on the project
	As a client of the Web Api
	I want to be able to Create, Update, Delete, and Read posts.


@HappyPath-CREATE
	Scenario Outline: Add Post
	Given I create a new post with (<userId>,'<title>','<body>',<id>)
	Then the system should return <StatusCode>

Examples:
	| userId | title               | body                  | id | StatusCode |
	| 1      | A EyeCatching Title | A powerful body       | 2  | 201        |
	| 2      | A Fantastic Title   | A empowering message  | 3  | 201        |
	| 3      | A Wonderful Title   | A wholesome paragraph | 4  | 201        |


@HappyPath-GET
	Scenario Outline: Get Post
	When I request to view post with id <id>
	Then system should return <StatusCode>
	And system should reutrn post header (<userId>,'<title>','<body>',<id>)

Examples: 
	| userId | title			 | body									   | StatusCode | id  |
	| 1		 | Outstanding title | This is a long discription of the body  | 200		|  1  |

@HappyPath-DELETE
Scenario Outline: Delete Post
	Given There exists a post with id 1
    When I delete a post
	Then the system should return success code

@HappyPath-UPDATE
Scenario Outline: Update Post
	Given There exists a post with <id>
	When I update an existing property ('<newTitle>','<newBody>')
	Then the response post should have value (<id>,'<newTitle>','<newBody>',<userId>);

Examples: 
	| userId | newTitle             | newBody             | id |
	| 1      | A brand New title    | A brand New Body    | 1  |


Scenario Outline: Query Does Not Exists
	When I request a post that does not exists
	Then the response should not be successful