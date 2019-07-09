## Assets Mangement Website

### I. Introduction

- This document aims to describe the design of the screen details of the modules of the fixed asset management program.
- Documentation to help the project team capture details of the main functions that the project team will design.
- This document will serve the members of the project team, the project manager, the project manager, the QA to review, revise the functions, raise comments and suggestions for the design phase.

### II. Business process

#### 1. Description of handling:

This is a module to manage all assets in use throughout the system, assets managed by each unit and automatically calculate monthly depreciation expenses for each unit. The asset management module should manage the following three types of assets:

- Fixed assets / labor tools.
- Real estate
- Special assets (vehicles / vehicles)
  According to the general provisions of the Tax, assets are divided into 02 categories depending on the value of the cost of the assets:
- Working tools: in case the original value is less than VND 30 million.
- Fixed assets: case of original value of VND 30 million or more.
  This price value parameter will be parameterized, allowing the user to update when there is a change in tax policy.

#### 2. Enter new assets

Assets are managed by asset groups, asset groups are organized in the form of N-grade trees. The list of asset groups is organized in accordance with the general provisions of the Tax and separate regulations. Asset groups will have the following attributes:

- Property group code.
- Property group name.
- Asset type: there are 2 values of fixed assets or labor tools.
- Accounts related to accounting
  o Property account
  o Depreciation account
  o Download the cost
  o Income account
  o Account for liquidation costs.
- Period of depreciation
- Depreciation rate: always equal to 1 because GSOFT is currently depreciating in a straight line.
  Warehouse management on the system is only logically managed. The warehousing is just an update on the property to manage this asset being used in the unit or it has been imported or recalled, and the actual location of the property can be located at any any unit across the system.
  Performing to enter new assets when receiving deliveries from suppliers, the information to enter when entering new assets:
- Asset type: Fixed asset / labor contract
- Asset group: select in the list of asset groups, this list will display corresponding to the selected value in the asset type area.
- Property / tool code: the system will implement unique code for each fixed asset / labor force. Property code will be granted automatically according to the increasing numbering principle and granted according to the following format:
  o Format property code: XYYYZZZZZZ (10 characters). Inside:
   X: Asset type, there are 2 values: T: fixed assets; C: Dynamic tool (1 character)
   YYY: is the asset group code, consisting of 3 characters
   ZZZZZZ: is a sequence of self-increasing numbers, consisting of 6 characters
- Name of property / tool.
- Configuration / Series / description information
- Warranty information and warranty schedule.
- Supplier: select from supplier list
- Cost of assets
- Price of depreciation: default is equal to the original price of the asset, allowing editing in a special case. For example, the car is worth over 1 billion 6.
- Depreciation rate: defaulted from asset group, allowed to edit (due to assets being land use right depreciation rate is calculated according to usage time).
- Date of asset entry
- Note
  The system supports 2 methods of entering new assets:
- Enter assets in batches: when entering goods in contracts with large quantities, the property has the same detailed information. Using this function to enter new assets, then the system will automatically generate many corresponding and continuous asset codes.
- Individual asset entry: used for the purchase of assets in small quantities.
  In the case, the supplier delivers directly to the user, the system supports the import of new assets and automatically handles implicitly under the import / export process.
