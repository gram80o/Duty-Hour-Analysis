   M S B A M L   `   `   `  ����D  @TestLabor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TestLabor.ControlsTestLabor.Controls  5      0    *TestLabor.Controls.EmployeeScheduleControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:TestLabor.Controls     5      -   5        .��5	      �   � RowDefinitions  5
   
   �� 5      $
��auto �6   �� 5      .+�5   
   �� $��0��6   
�������$��0,0,0,1q�61   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      �  � Color$ 	#FFD2D2D2��6#    � Offset$ 0Q�65   � 5      $ 	#FFF1ECEC��6#   $ 0.211Q�65   5      ._�5      � -   5        $��panelHeader��5      $��5q�6&    � ColumnDefinitions 5      �� 5      $
��auto �6'   �� 5      .+�5      ��  �� CornerRadius$ 5��6   
�������$��1q�6B   
�������._�5      �� $	��250��6   $	��175��6)   ��65   �� *	ImagePath+5       � 5#      $��1��6   $��10q�6'    5$      �� 5%      $
��auto �6+   �� 5&        5(      �� 5)      $
��auto �6(   �� 5*      $
��auto �6(   �� 5+      $
��auto �6(   �� 5,      $
��auto �6(   �� 5-      $
��auto �6(   .+�51      �� $��0��6    $��2��60   $��0��6D   $
��Left=�6Q   $��Center=�6l   $��20(�6�   $��DemiBold"�6�   ��6�   �� *
FullName+�� 54      $��0��6    $��1��60   $
��Left=�6=   $��Center=�6X   $��13(�6s   $��DemiBold"�6�   $��
Position: ��6�   $��0,2,2,2q�6�   �� 55      $��1��6    $��1��60   $
��Left=�6=   $��Center=�6X   $��13(�6s   $��2,0,0,0q�6�   ��6�   �� *
Position+6�   �� 58      $��0��6    $��2��60   $
��Left=�6=   $��Center=�6X   $��13(�6s   $��DemiBold"�6�   $��Date of Birth: ��6�   $��0,2,2,2q�6�   �� 59      $��1��6    $��2��60   $
��Left=�6=   $��Center=�6X   $��13(�6s   $��2,0,0,0q�6�   ��6�   �� *DateOfBirth+6�   �� 5<      $��0��6    $��3��60   $
��Left=�6=   $��Center=�6X   $��13(�6s   $��DemiBold"�6�   $��Gender: ��6�   $��0,2,2,2q�6�   �� 5=      $��1��6    $��3��60   $
��Left=�6=   $��Center=�6X   $��13(�6s   $��2,0,0,0q�6�   ��6�   �� *Gender+6�   �� 5@      -   5        $��btnRunDutyHourAnalysis��5@      $��4��6;   $��0,5,0,0q�6H   $��25��6Y      ToolbarButtonsRun#��[  6e    � ToolTip$; 5Runs the Duty Hour Analysis on the selected employees��5A   B   ��5B      � 5C       5D   "   �� 5E   &   $
��auto �67   �� 5F   &   .+�5J   "   �� $��0��6(   $��12��68   $��12��6D   $)��#/TestLabor;component/Images/run.png��6O   �� 5M   "   $��1��6,   $��5,0,0,0q�6<   $��Center=�6M   $��11(�6h   $��Run Duty Analysis��6v   5N      5P      5Q      5S      5T      &   System.Windows.Controls.DataGrid  5W   
   -   5        $��datagridSchedules��5W      $��1��6,   $��0q�69      Columns 5X      0  *System.Windows.Controls.DataGridTextColumn  5Y      ,  &System.Windows.Controls.DataGridColumn	   Header$	 	Start Day��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 68   �� *TheStartDayOfTheWeek+  5Z      $	 Shift Start��6%      MinWidth$	 130Q�6:   
 6I   �� *StartDateTime+  5[      $	 End Day��6%   
 66   �� *TheEndDayOfTheWeek+  5\      $	 	Shift End��6%   $	 130Q�68   
 6G   �� *EndDateTime+  5]      $	 Hours��6%   
 64   �� *CalculatedHours+5_      5a      5b      