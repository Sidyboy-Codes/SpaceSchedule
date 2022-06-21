# Space Schedule 🚀
A small CMS project. This project is at admin level, admin can add, update, edit, or delete space schedule data using a user friendly UI (do not need to access database directly). Data consist of Space agencies, Rockets from space agencies and launch schedule of each rocket. This data then can be displayed in nice UI for space launch schedule blog/page.

This project demonstrate use of all CRUD operation using C#, LINQ and Entity Framework.

## How to use this website?
1. Launches: On admin page, in navigation bar admin can click "launches" and can view all scheduled launches.
	* Admin can add new launch using "add a launch" button.
	* Admin can view details of each launch clicking the launch it self.
	* Admin can delete the launch using "delete" button present on details page.
	* Admin can edit the details of launch clicking "edit" button present on details page.
	* Admin can directly view details of rocket that is being used for that launch (on detais) clicking on rocket name.

2. Rockets: On admin page, in navigation bar admin can click "Rockets" and can view all rockets.
	* Admin can add new rocket using "add a rocket" button.
	* Admin can view details of each rocket clicking the rocket name it self.
	* Admin can delete the rocket using "delete" button present on details page.
	* Admin can edit the details of rocket clicking "edit" button present on details page.
	* Admin can view all launches of current rocket whos detailed is being viewed.
	* Admin can directly get details of space agency of current rocket whos detail is being viwed by clicking on space agency name.

3. Space agencies: On admin page, in navigation bar admin can click "Space agency" and can view all space agencies.
	* Admin can add new space agency using "add a space agency" button.
	* Admin can view details of each space agency clicking the space agency name it self.
	* Admin can delete the space agency using "delete" button present on details page.
	* Admin can edit the details of space agency clicking "edit" button present on details page.
	* Admin can view all rockets of current space agency whos detailed is being viewed.
