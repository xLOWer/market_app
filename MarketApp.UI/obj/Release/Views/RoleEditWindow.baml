   M S B A M L   `   `   `  ����   MarketApp.UI'    !MarketApp.UI.Views.RoleEditWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  l hDevExpress.Xpf.Core.v20.1.Extensions, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a=dx2http://schemas.devexpress.com/winfx/2008/xaml/core   l hDevExpress.Xpf.Grid.v20.1.Extensions, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v20.1.Core, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid    c	 _DevExpress.Xpf.Ribbon.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon 	  <d2http://schemas.microsoft.com/expression/blend/2008 	  R
 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 
    Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006 
      � Title$  RoleEditWindow��$	��450��$	��600�� � 	Resources  �� Source�� $ ../Styles.xaml?�%    .���  � RowDefinitions �� $
��Auto ��� $��* �.+�) 	 #DevExpress.Xpf.Ribbon.RibbonControl  $��0��   ribbonControlStyle#��[     Items. 5 	 /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2 	 ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase   Pages. & 	  DevExpress.Xpf.Ribbon.RibbonPage     Caption)  #DevExpress.Xpf.Core.ObjectConverter$ Роль    Groups. + 	 %DevExpress.Xpf.Ribbon.RibbonPageGroup     Caption$  ��	   Items.	 '  !DevExpress.Xpf.Bars.BarButtonItem  !  DevExpress.Xpf.Bars.BarItem
   Content$
 Сохранить    RibbonStyle$ Large=�   Command �� *SaveCommand+   Glyph *	  $DevExpress.Xpf.Core.DXImageExtension	  *%#SvgImages/Outlook Inspired/Save.svg+� $
��Auto��$��3�� �� $
��Auto ��� $��* �.+��� $��0��  hStackPanelStyle#��[ .+��� $��Наименование��  label200Style#��[ ��   field300Style#��[ ���� *	Role.Name+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�� $��1�� � ColumnDefinitions �� $
��Auto ��� $��50 ��� $
��Auto � �� $
��Auto ��� $��* �.+��� $��0��$��0��$
��10 5q�$
��Bold"�$��Текущие права���� $��2��$��0��$
��10 5q�$
��Bold"�$#��Доступные права��%
  DevExpress.Xpf.Grid.GridControl
  -    
 Name$ permsDataGrid��$��0��$��1��$��5q�$	��250��)  #DevExpress.Xpf.Grid.DataControlBase   
ShowBorder .     ItemsSource �� *RolePermissionSource+$ PropertyChanged=�   SelectedItem �� *SelectedRolePermission+$ TwoWay=�$ PropertyChanged=� 
  Columns $  DevExpress.Xpf.Grid.GridColumn  $  DevExpress.Xpf.Grid.BaseColumn   Header$ 
Право $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$
 Name��   Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$ *  
  View #  DevExpress.Xpf.Grid.TableView  -     Name$ 	permsView��&   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .  &   DevExpress.Xpf.Grid.DataViewBase   ShowSearchPanelMode$ Always=�   AllowEditing .     NavigationStyle$
 Cell=�   GroupSummaryDisplayMode$ AlignByColumns=�    ShowTotalSummary  . !   ShowSelectionRectangle! . "   AllowBestFit" . �� # �� Orientation$# Vertical=�$	��Top=�$��1��$��1��.+��� $	��0 5q����� *AddPermCommand+.���� $��Uniform=���4  .DevExpress.Xpf.Core.DXImageOffice2013Extension  $   Image;  5DevExpress.Xpf.Core.Native.DXImageOffice2013Converter$$ Prev_32x32.png �� $	��0 5q����� *RemovePermCommand+.���� $��Uniform=���  $$ Next_32x32.png 
  -   $ availPermsDataGrid��$��2��$��1��$��5q�$	��250�� .   �� *AvailablePermissionSource+$ PropertyChanged=� �� *SelectedAvailablePermission+$ TwoWay=�$ PropertyChanged=�   $ 
Право $
 Name��$ *    -   $ availPermsView�� .  $ Always=� .  $
 Cell=�$ AlignByColumns=�  . ! . %%   ShowCheckBoxSelectorInGroupRow% . " . 