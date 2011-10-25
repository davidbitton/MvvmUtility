MvvmUtility
===========

MvvmUtilty is a collection of classes that make creating an MVVM RI app using Prism easier.

An overview of MvvmUtility
==========================

Commanding
----------

[PrismCommandRegistry][] allows for a single aggregation point for all commands in a ViewModel.
The purpose for this is to be able to fire each CanExecute method for [ICommand][] with a single
call.

Author	:	David B. Bitton (david@codenoevil.com)