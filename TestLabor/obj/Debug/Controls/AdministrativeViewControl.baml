   M S B A M L   `   `   `  ����D  @TestLabor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TestLabor.ControlsTestLabor.Controls  5      2    ,TestLabor.Controls.AdministrativeViewControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:TestLabor.Controls     5      -   5        .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��0��6   $��16(�6!   $��DemiBold"�6/   $��5q�6E   $��Administrative View��6P   �� 5   
   $��1��6   $��12(�6!   $��5,0,5,5q�6/   $M��GSelect the employees that you would like to run a Duty Hour Analysis on��6@   � 5   
   -   5        $��panelToolsAndButtons��5      $��2��6+   $��5,0,5,5q�68    � ColumnDefinitions 5      �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5      $
��auto �6#   �� 5       $
��auto �6#   .+�5$      �� -   5        $��btnSelectAll��5$      $��0��6)      ToolbarButtons#��[  69   $��
Select All��6a    � ToolTip$" Selects all of the employees��6�   �� 5'      -   5        $��btnSelectNone��5'      $��1��6*   #��[  6:   $��Select None��6b   $. (Removes the selection from all employees��6�   �� 5*      -   5        $��btnRunDutyHourAnalysis��5*      $��2��63     ToolbarButtonsRun#��[ 6C   $; 5Runs the Duty Hour Analysis on the selected employees��6�   ��5+      � 5,       5-      �� 5.      $
��auto �6/   �� 5/      .+�53      �� $��0��6    $��12��60   $��12��6<   $)��#/TestLabor;component/Images/run.png��6G   �� 56      $��1��6$   $��5,0,0,0q�64   $��Center=�6E   $��11(�6`   $��Run Duty Analysis��6n   57      59      5:      �� 5=   
   -   5        $��scrollEmployees��5=      $��3��6.   $��Disabled=�6;   $
��Auto=�6d   .��5>      �� -   5        $��lboEmployees��5>      ��5?      �� 5@      .R�5A      �  � Orientation$ 
Horizontal=�6$   5B      5D      5E      5H      5I      