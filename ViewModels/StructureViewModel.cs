using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace Showcase.WPF.DragDrop.ViewModels
{
   

    public class StructureViewModel : ViewModelBase
    {

        private string _name;
        private string _path;
        private string _type;
        private ImageSource _icon;
        private bool _isExpanded;
        private bool _isSelected;

        private StructureViewModel _parent;

        private ObservableCollection<StructureViewModel> _folders;
        private ObservableCollection<StructureViewModel> _files;

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                if (SetProperty(ref _isExpanded, value))
                {
                    Refresh();
                }
            }
        }

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (SetProperty(ref _isSelected, value))
                {
                    if (value)
                    {
                        IsExpanded = true;
                    }
                }
            }
        }

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Path
        {
            get => _path;
            set => SetProperty(ref _path, value);
        }

        public string Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        public StructureViewModel Parent
        {
            get => _parent;
            set => SetProperty(ref _parent, value);
        }

        public ObservableCollection<StructureViewModel> Files
        {
            get => _files ??= new ObservableCollection<StructureViewModel>();
            set => SetProperty(ref _files, value);
        }

        public ObservableCollection<StructureViewModel> Folders
        {
            get => _folders ??= new ObservableCollection<StructureViewModel>();
            set => SetProperty(ref _folders, value);
        }

        public ImageSource Icon
        {
            get
            {

                try
                {

                    if (_icon != null)
                    {
                        return _icon;
                    }

                    if (Type == "Folder")
                    {
                        _icon = IconExtractor.GetFolderIcon(Path).ToImageSource();
                    }
                    else
                    {
                        _icon = IconExtractor.GetFileIcon(Path).ToImageSource();
                    }

                    return _icon;
                }
                catch
                {
                    throw;
                }
            }
        }

        private StructureViewModel AddFolder(string folder)
        {

            try
            {
                DirectoryInfo di = new(folder);

                if ((di.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden)
                {
                    StructureViewModel newFolder = new StructureViewModel
                    {
                        Name = di.Name,
                        Path = di.FullName,
                        IsExpanded = false,
                        IsSelected = false,
                        Type = "Folder"
                    };// FsoUtils.CreateFolderViewModel(folder, this);
                    Folders.Add(newFolder);
                    return newFolder;
                }

                return null;
            }
            catch
            {
                throw;
            }
        }

        public void Refresh(bool forceReload = false)
        {
            try
            {
                if (forceReload)
                {
                    Folders.Clear();
                }

                if (Folders.Count > 0)
                {
                    return;
                }

                Folders.Clear();

                string[] folders = Directory.GetDirectories(Path);

                if (folders != null)
                {
                    foreach (string folder in folders)
                    {
                        _ = AddFolder(folder);
                    }
                }

                //Folders.Sort(t => t.Name, ListSortDirection.Ascending);

            }
            catch
            {
                throw;
            }
        }
    }
}
