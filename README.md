# Github User Activity
A software recommended to be made https://roadmap.sh/projects/github-user-activity

## Features
Lets you list down the recent activities of a github user
This software only lists details on the following github event types:
1. PushEvent
2. CreateEvent
3. PullRequestEvent
4. MemberEvent
5. IssueCommentEvent
6. ForkEvent
7. IssuesEvent

To see more regarding the github events, see https://github.com/JyanMan/GitUserActivity

## How to use
1. first navigate to bin/Release/net9.0/publish
2. You could install all the publish folder, or clone the github repository and navigate to bin/Release/net9.0/publish
3. Open command prompt within the directory (where the GithubUserActivity.exe is located)
4. Now type the following command to open the software and indicate the github-username to see the activities of that account
- in windows: `GithubUserActivity.exe <github-username>`
- in linux: `./GithubUserActivity <github-username>`

For example:
   `GithubUserActivity.exe JyanMan`
   this will show all my recent activities

## Note
I kind of do not understand some of the github events types in their api so some events have no resulting line.
Such as the watchevent, the software will just indicate what the player did like, "WatchEvent", but details will not be indicated.


