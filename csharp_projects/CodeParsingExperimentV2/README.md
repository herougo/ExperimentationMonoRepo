\# CodeParsingExperimentV2



\## TODO



1\) \[ ] (1.5d) Input is a code base folder, output is a "SourceMetadata" folder of json files with metadata (with global complete flag)

2\) \[ ] (0.5h) Input is a "SourceMetadata" folder, and the output is a base "Mapping" folder (with a log of IDs of completed migrations)

3\) \[ ] (0.75d) Input is a "Mapping" folder, and the result is a destination repo

&nbsp;   - \[ ] (0.25d) Copy-pasting enums and models (using SourceMetadata and Mapping)

&nbsp;   - \[ ] (0.25d) Rename uses of class/enum types

&nbsp;   - \[ ] (0.25d) Replace uses of static methods

7\) \[ ] (0.1d) Topological sort of methods

8\) \[ ] (???) Iterative method migration planning

9\) \[ ] (???) Handle service structure (representing the structure, ensuring the mapping works, adding constructor arguments)

10\) \[ ] (0.5d) Managing imports

11\) \[ ] (???) How do we handle incremental changes to the mapping folder, and having that reflect in the repo?



\## Minor



Incorporate building step





\## Maybe



1\) Handling whitespace issues

