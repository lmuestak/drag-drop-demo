using GongSolutions.Wpf.DragDrop;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;

namespace Showcase.WPF.DragDrop.ViewModels
{

    public interface IDragAndDropHandler : IDragSource, IDropTarget
    {

    }

    public class StructureManagerViewModel: ViewModelBase, IDragAndDropHandler
    {
        public StructureManagerViewModel()
        {
            foreach (var item in System.Environment.GetLogicalDrives())
            {
                var di = new DirectoryInfo(item);

                Items.Add(new StructureViewModel()
                {
                    Name = di.Name,
                    Path = di.FullName,
                    IsExpanded = false,
                    IsSelected = false,
                    Type = "Folder",
                });
            }

            if (Items.Count > 0)
                Items.FirstOrDefault().IsSelected = true;
        }

        private ObservableCollection<StructureViewModel> _items;

        public ObservableCollection<StructureViewModel> Items
        {
            get { return _items ??= new ObservableCollection<StructureViewModel>(); }
            set { SetProperty(ref _items, value); }
        }

        public void StartDrag(IDragInfo dragInfo)
        {
            //throw new NotImplementedException();
        }

        public bool CanStartDrag(IDragInfo dragInfo)
        {
            return true;// throw new NotImplementedException();
        }

        public void Dropped(IDropInfo dropInfo)
        {
            //throw new NotImplementedException();
        }

        public void DragDropOperationFinished(DragDropEffects operationResult, IDragInfo dragInfo)
        {
            //throw new NotImplementedException();
        }

        public void DragCancelled()
        {
            //throw new NotImplementedException();
        }

        public bool TryCatchOccurredException(Exception exception)
        {
            return true; //throw new NotImplementedException();
        }

        public void DragOver(IDropInfo dropInfo)
        {
            //throw new NotImplementedException();
        }

        public void Drop(IDropInfo dropInfo)
        {
            //throw new NotImplementedException();
        }
    }
}
