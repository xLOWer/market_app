   M S B A M L   `   `   `  ����  MarketApp.UI'    !MarketApp.UI.Views.RoleEditWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35a ]DevExpress.Xpf.Core.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aW SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      <dxb2http://schemas.devexpress.com/winfx/2008/xaml/bars  5      l hDevExpress.Xpf.Core.v20.1.Extensions, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a=dx2http://schemas.devexpress.com/winfx/2008/xaml/core   5      l hDevExpress.Xpf.Grid.v20.1.Extensions, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aa ]DevExpress.Xpf.Grid.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49af bDevExpress.Xpf.Grid.v20.1.Core, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxg2http://schemas.devexpress.com/winfx/2008/xaml/grid    5      c	 _DevExpress.Xpf.Ribbon.v20.1, Version=20.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a@dxr4http://schemas.devexpress.com/winfx/2008/xaml/ribbon 	  5      <d2http://schemas.microsoft.com/expression/blend/2008 	  5      R
 NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml 
    5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006 
    5	        � Title$  RoleEditWindow��5   	   $	��450��6    $	��600��6-    � 	Resources 5       �� Source�� 5   
   $ ../Styles.xaml?�6   %    .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ) 	 #DevExpress.Xpf.Ribbon.RibbonControl  $��0��6      ribbonControlStyle#��[  6)      Items. 5      5 	 /DevExpress.Xpf.Ribbon.RibbonDefaultPageCategory  2 	 ,DevExpress.Xpf.Ribbon.RibbonPageCategoryBase   Pages. 5      & 	  DevExpress.Xpf.Ribbon.RibbonPage     Caption)  #DevExpress.Xpf.Core.ObjectConverter$ Роль 6!      Groups. 5      + 	 %DevExpress.Xpf.Ribbon.RibbonPageGroup     Caption$  ��6*   	   Items.	 5      '  !DevExpress.Xpf.Bars.BarButtonItem  !  DevExpress.Xpf.Bars.BarItem
   Content$
 Сохранить 6,      RibbonStyle$ Large=�5   ,      Command 5   ,   �� *SaveCommand+   Glyph 5   ,   *	  $DevExpress.Xpf.Core.DXImageExtension	  *%#SvgImages/Outlook Inspired/Save.svg+5      5       5!      5"      � 5#   
   $
��Auto��6   $��3��6    5$      �� 5%      $
��Auto �6    �� 5&      $��* �6    .+�5)      �� $��0��6     hStackPanelStyle#��[ 6&   .+�5*      �� $��Наименование��6     label200Style#��[ 6/   �� 5+        field300Style#��[ 6g   ��6   �� *	Role.Name+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6g   5,      � 5.      $��1��6    � ColumnDefinitions 50      �� 51      $
��Auto �6'   �� 52      $��50 �6'   �� 53      $
��Auto �6'    56      �� 57      $
��Auto �6$   �� 58      $��* �6$   .+�5;      �� $��0��6   $��0��6(   $
��10 5q�65   $
��Bold"�6C   $��Текущие права��6U   �� 5<      $��2��6   $��0��6(   $
��10 5q�65   $
��Bold"�6C   $#��Доступные права��6U   %
  DevExpress.Xpf.Grid.GridControl
  5>      -   5         
 Name$ permsDataGrid��5B      $��0��5>   "   $��1��62   $��5q�5?      $	��250��5@      )  #DevExpress.Xpf.Grid.DataControlBase   
ShowBorder .     ItemsSource 5C      �� *RolePermissionSource+$ PropertyChanged=�   SelectedItem 5D      �� *SelectedRolePermission+$ TwoWay=�$ PropertyChanged=� 
  Columns 5F      $  DevExpress.Xpf.Grid.GridColumn  5G      $  DevExpress.Xpf.Grid.BaseColumn   Header$ 
Право 6)   $  DevExpress.Xpf.Grid.ColumnBase   	FieldName$
 Name��68      Width2  ,DevExpress.Xpf.Grid.GridColumnWidthConverter$ * 6I    
  View 5J      #  DevExpress.Xpf.Grid.TableView  5K      -   5          Name$ 	permsView��5L       &   DevExpress.Xpf.Grid.GridViewBase   ShowGroupPanel .  &   DevExpress.Xpf.Grid.DataViewBase   ShowSearchPanelMode$ Always=�5M          AllowEditing .     NavigationStyle$
 Cell=�5O          GroupSummaryDisplayMode$ AlignByColumns=�5P           ShowTotalSummary  . !   ShowSelectionRectangle! . "   AllowBestFit" . 5S       5V      �� 5X      # �� Orientation$# Vertical=�6   $	��Top=�64   $��1��6L   $��1��6]   .+�5Y      �� $	��0 5q�6   ��6*   �� *AddPermCommand+.��5Z      �� $��Uniform=�6U   ��6    4  .DevExpress.Xpf.Core.DXImageOffice2013Extension  $   Image;  5DevExpress.Xpf.Core.Native.DXImageOffice2013Converter$$ Prev_32x32.png 6U   5[      �� 5\      $	��0 5q�6   ��6*   �� *RemovePermCommand+.��5]      �� $��Uniform=�6U   ��6      $$ Next_32x32.png 6U   5^      5_      
  5a      -   5        $ availPermsDataGrid��5e      $��2��5a   "   $��1��62   $��5q�5b      $	��250��5c       .   5f      �� *AvailablePermissionSource+$ PropertyChanged=� 5g      �� *SelectedAvailablePermission+$ TwoWay=�$ PropertyChanged=� 5h        5i      $ 
Право 6)   $
 Name��68   $ * 6J    5l        5m      -   5        $ availPermsView��5n        .  $ Always=�5o        .  $
 Cell=�5q       $ AlignByColumns=�5r         . ! . %%   ShowCheckBoxSelectorInGroupRow% . " . 5v       5y      5z      5{      5|      5}      