# IbanLib
###The library permits to manage all the information and validations about an IBAN in all the supported countries.

The library was totally thought for a fully personalization of the user defining all the interfaces in a separated project that could live alone.
All the implementations of the library does not depends from any other project but just from the interfaces. In this way all the default implementations that are provided are fully configurabiles simply configuring the IoC choosed.

Fully supported countries in the version 1.0.0:
* AD - Andorra,
* AL - Albania,
* AT - Austria,
* BE - Belgium,
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
* SM - San Marino,
* TR - Turkey,
* VG - Virgin Islands

All the missing countries need times to be integrated because it is not so easy to find all the required information needed from the library for every single country.

##Structure of the solution
The solution is structured under three main folders:
* Folder _**Library**_ where we can find all the interfaces and implementations of the library,
* Folder _**Samples**_ where we can find all the sample (similar to integration tests) of the library implementation,
* Folder _**Tests**_ where we can find all the UnitTest for the library.


##Structure of the _Library_ folder
The library is structured under eight projects:
* _**IbanLib**_ contains all the defaul implementation to use the library,
* _**IbanLib.Common**_ contains the common structures and functionalities shared between the other projects,
* _**IbanLib.Countries**_ contains the generic interface for a country and all the country integrated,
* _**IbanLib.DependenciesResolver**_ contains the configuration for the IoC (in this case _[Castle](www.castleproject.org)_),
* _**IbanLib.Domain**_ contains all the interface for the library,
* _**IbanLib.Exceptions**_ contains all the Exceptions that the library can throwns,
* _**IbanLib.Splitters**_ contains the default implementations for all the splitters that the project _IbanLib_ uses,
* _**IbanLib.Validators**_ contains the default implementations for all the validators that the project _IbanLib_ uses,

##How to start
How it is showed under the samples projects the library was thought to permits to manage or an _IbanLib.Domain.IIban_ object or an _IbanLib.Domain.IBban_ object.

###BBAN
The default implementation offers from the library to manage an _IbanLib.DomainIBban_ is the _IbanLib.Bban_ object.
This object has three constructors and every one of those could be used in the folling examples:

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
The default implementation offers from the library to manage an _IbanLib.DomainIIban_ is the _IbanLib.Iban_ object.
This object has three constructors and, in similar way of the BBAN, every one of those could be used in the folling examples:

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
