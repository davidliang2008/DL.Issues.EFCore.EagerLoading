# DL.Issues.EFCore.EagerLoading

This repository is for the investigation of EF Core Eager Loading issue I found (previously opened at https://github.com/aspnet/EntityFrameworkCore/issues/11860).

It seems like random items from the source collection won't load their collection navigation properties when there is additional filter like .Contain() involved.
