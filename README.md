# PutridParrot.Maui

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
