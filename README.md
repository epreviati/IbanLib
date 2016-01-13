# IbanLib
###The library permits to manage all the information and validations about an IBAN in all the supported countries.

The library was thought for a fully personalization of the user, defining all the interfaces in a separated project that could be used alone.
For this reason, all the classes of the library does not depends from any other component but just from the interfaces. In this way all the default objects that are provided are fully configurable simply configuring the IoC container choosed.

Countries supported in version 1.0.0:
* AD - Andorra,
* AE - United Arab Emirates,
* AT - Austria,
* AZ - Azerbaijan,
* BE - Belgium,
* BH - Bahrain,
* BR - Brazil,
* CR - Costa Rica,
* DE - Germany,
* ES - Spain,
* FR - France,
* GB - United Kingdom,
* IE - Ireland,
* IT - Italy,
* MC - Monaco,
* MD - Moldova,
* MR - Mauritania,
* RO - Romania,
* SA - Saudi Arabia,
* SM - San Marino,
* TR - Turkey,
* VG - Virgin Islands

To integrate all the other missing countries is still required more because it is not so easy to find all the required informations for every single country.

##Structure of the solution
The solution is structured under three main folders:
* Folder _**Library**_ where there are all the interfaces and implementations of the library,
* Folder _**Samples**_ where there are the basic samples (similar to integration tests) of the library,
* Folder _**Tests**_ where there are all the Unit Tests for the library.


##Structure of the _Library_ folder
The library is structured under eight projects:
* _**IbanLib**_ contains all the default implementation to use the library,
* _**IbanLib.Common**_ contains the common structures and common functionalities shared between the other projects,
* _**IbanLib.Countries**_ contains the generic interface, ICountry, for a country and all the implemented countries,
* _**IbanLib.DependenciesResolver**_ contains the configurations for the IoC (by default is used _[Castle](http://www.castleproject.org/)_),
* _**IbanLib.Domain**_ contains all the interfaces to the library,
* _**IbanLib.Exceptions**_ contains all the Exceptions that the library can throw,
* _**IbanLib.Splitters**_ contains the default implementations for all the splitters that the project _IbanLib_ uses,
* _**IbanLib.Validators**_ contains the default implementations for all the validators that the project _IbanLib_ uses,

##How to start
How it is shown under the samples projects the library was thought to permits to manage or an _IbanLib.Domain.IIban_ object or an _IbanLib.Domain.IBban_ object.

###BBAN
The default implementation, offered from the library, allow to manage an _IbanLib.Domain.IBban_ is the _IbanLib.Bban_ object.
This object has three constructors and every one of those could be used in the following examples:

####Empty constructor
```
var bban = new Bban();
```

####Basic constructor
```
IbanLib.Countries.ICountry country = new ...;
string bankCode = "...";
string branchCode = "...";
string accountNumber = "...";
IbanLib.Domain.IValidators validators = new ...;

var bban = new Bban(country, bankCode, branchCode, accountNumber, validators);
```

####Splitter constructor
```
IbanLib.Countries.ICountry country = new ...;
string bban = "...";
IbanLib.Domain.IValidators validators = new ...;
IbanLib.Domain.Splitters.IBbanSplitter ibanSplitter = new ...;

var bban = new Bban(country, bban, validators, splitters);
```

###IBAN
The default implementation, offered from the library, allow to manage an _IbanLib.Domain.IIban_ is the _IbanLib.Iban_ object.
This object has three constructors and, in similar way for the BBAN, every one of those could be used in the following examples:

####Empty constructor
```
var iban = new Iban();
```

####Basic constructor
```
IbanLib.Countries.ICountry country = new ...;
IbanLib.Domain.IBban bban = new ...;

var iban = new Iban(country, bban);
```

####Splitter constructor
```
string iban = "...";
IbanLib.Domain.ICountryResolver countryResolver = new ...;
IbanLib.Domain.IBban bban = new ...;
IbanLib.Domain.IValidators validators = new ...;
IbanLib.Domain.Splitters.IIbanSplitter ibanSplitter = new ...;
IbanLib.Domain.Splitters.IBbanSplitter bbanSplitter = new ...;

var iban = new Iban(iban, countryResolver, bban, validators, ibanSplitter, bbanSplitter);
```
