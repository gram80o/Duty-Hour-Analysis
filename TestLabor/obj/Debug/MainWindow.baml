   M S B A M L   `   `   `  ����D  @TestLabor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:TestLabor	TestLabor  5   	       TestLabor.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:TestLabor     5   	   -   5          � Title$  Duty Hour Analysis��5   	   $	��650��6$   $
��1050��61    � WindowState$ 	Maximized=�6U   
���   � � 	Resources 5	         Storyboard_OpenChildWindow �� 
TargetName �� TargetProperty O� KeyTime O� Value  Storyboard_CloseChildWindow��%�  &	        &	 �     �� 5
   
   .��5      U� $ 	panelMain��6,   $ (UIElement.Opacity)�6N   .\�5      �� $ 0:0:0��6'   $	 1.0Q�67   �� 5      $ 0:0:0.5��6'   $	 0.3Q�69   5      5      �� 5   
   .��5      U� $ 	panelMain��6,   $ (UIElement.Opacity)�6N   .\�5      �� $ 0:0:0��6'   $	 0.3Q�67   �� 5      $ 0:0:0.5��6'   $	 1.0Q�69   5      5      5      .��5      � -   5        $��	panelMain��5      
������� � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      �� 5      $
��auto �6   .+�5!   
   �� -   5        $��borderMenuMain��5!      $��0��6'   
�������$��0,0,0,1q�6G   ._�5"      o� -   5        $��menuMain��5"      
�������.@�5#      m� $
��File��6   .@�5$      m� -   5        $��miExitApplication��5$      $
��Exit��68    � ToolTip$ Exits the application��6F   6f   5%      5&      5'      � 5*   
   -   5        $��panelMainBoard��5*      $��3��6%   $��2,10,2,2q�62   �� 5.   
   -   5        $��borderStatusMain��5.      $��4��6)   ._�5/      �� -   5        $��
statusMain��5/      
�������$��0,1,0,0q�6=   .@�50      �� .��51      �� -	   5        $��lblBusinessDay��51       $��11(�66   52      �� 53      �� 54      .��55      �� -
   5        $��lblRoleName��55       $��11(�63   56      �� 57      �� 58      59      5:      5;      5<      