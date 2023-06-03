# PutridParrot.Maui

[![Build PutridParrot.Maui](https://github.com/putridparrot/PutridParrot.Maui/actions/workflows/build.yml/badge.svg)](https://github.com/putridparrot/PutridParrot.Maui/actions/workflows/build.yml)
[![NuGet version (PutridParrot.Maui)](https://img.shields.io/nuget/v/PutridParrot.Maui.svg?style=flat-square)](https://www.nuget.org/packages/PutridParrot.Maui/)
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/putridparrot/PutridParrot.Maui/blob/master/LICENSE.md)
[![GitHub Releases](https://img.shields.io/github/release/putridparrot/PutridParrot.Maui.svg)](https://github.com/putridparrot/PutridParrot.Maui/releases)
[![GitHub Issues](https://img.shields.io/github/issues/putridparrot/PutridParrot.Maui.svg)](https://github.com/putridparrot/PutridParrot.Maui/issues)


A package for MAUI specific code.

## BindableCollection 

Originally known as the ExtendedObservableCollection (which is a bit of a mouthfall). The BindableCollection 
is basically an ObservableCollection which allows for deferred UI updating. For example in the ObservableCollection
if you're adding thousands of items, each addition results in the UI updating.

Deferred updating basically uses a BeginUpdate/EndUpdate pattern, whereby when you start a process that would 
result in multiple updates, you call BeginUpdate, when you've completed and want those updates propataged to 
the UI, then you call EndUpdate.

_Note: BeginUpdate/EndUpdate uses reference counting so that you can call BeginUpdate multiple times and only when 
the last, corresponding number of EndUpdate's are call will the UI update - hence you must ensure that for every 
BeginUpdate there is a corresponding EndUpdate._
