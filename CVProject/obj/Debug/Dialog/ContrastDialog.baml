   M S B A M L   `   `   `  ����D  @CVProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:CVProject.DialogCVProject.Dialog  5   	   U QInteractiveDataDisplay.WPF, Version=0.0.0.0, Culture=neutral, PublicKeyToken=nullkLclr-namespace:InteractiveDataDisplay.WPF;assembly=InteractiveDataDisplay.WPFInteractiveDataDisplay.WPF 5   	   %    CVProject.Dialog.ContrastDialog   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:CVProject.Dialog     5   	   [d3Lclr-namespace:InteractiveDataDisplay.WPF;assembly=InteractiveDataDisplay.WPF     5   	   X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	     � Title$  Adjust Contrast��5
   	   $	��423��6!   $	��800��6.   ���	#FF363636 � WindowStyle$ 
ToolWindow=�6Q    � WindowStartupLocation$ CenterScreen=�6j   .��5      � .+�5   
   	� -   5         	�Name$ 
rbtnLinear��5      $�� ��6*   $
��Left=�65   $��	10,10,0,0q�6P   $	��Top=�6c   6{   	� 5   
   -   5        $ rbtnLog��5      $�� ��6'   $
��Left=�62   $��
386,10,0,0q�6M   $	��Top=�6a   6y   	� 5   
   -   5        $ rbtnExp��5      $�� ��6'   $
��Left=�62   $��386,144,0,0q�6M   $	��Top=�6b   6z   �� 5   
   -   5         ��Name$ 
gboxLinear��5      $��Linear��6'   $
��Left=�67   $��	36,10,0,0q�6R   $	��Top=�6e   $	��345��6}   $	��372��6�   .��5      � .+�5      &   InteractiveDataDisplay.WPF.Chart  -   5          Name$ plotter��5      $��10,10,69,69q�6,   ���	#FF363636
�������   LegendContent 5      1  +InteractiveDataDisplay.WPF.LegendItemsPanel  5       � 	Resources 5       (  $InteractiveDataDisplay.WPF.LineGraph��%!   &	        �� 5   "   5   #   5      5         Title 5      �� 5      $��Center=�6$   $��9(�6A   $��0,5,0,5q�6N   .��5      � -   5        	 �Name$	 lines��5      5      #  Xceed.Wpf.Toolkit.RangeSlider  5      -   5        $��HSlider��5   #   $
��Left=�62   $��
39,278,0,0q�6M   $	��Top=�6a   $	��225��6y   
   Minimum$
 0Q�6�      Maximum$	 255Q�6�      
LowerValue$	 100Q�6�      HigherValue$	 200Q�6�     5       -   5        $��VSlider��5    #   $
��Left=�62   $��
269,32,0,0q�6M   $	��Top=�6a      Orientation$ Vertical=�6y   $	��211��6�   $
 0Q�6�   $	 255Q�6�   $	 100Q�6�   $	 200Q�6�   %  Xceed.Wpf.Toolkit.IntegerUpDown  5!      -	   5        $��x1��5!   %   $
��Left=�6/   $��
30,309,0,0q�6J   $	��Top=�6^   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value 6v   ��  �� ElementName$ HSlider�� �� Path$ 
LowerValue�6�   �� 5"      -
   5         ��Name$ label��5"      $��X1��6'   $
��Left=�64   $��
10,312,0,0q�6O   $	��Top=�6c     5#      -   5        $��x2��5#   %   $
��Left=�6/   $��110,309,0,0q�6J   $	��Top=�6_    6w   �� $ HSlider��$ HigherValue�6�   �� 5$      -   5        $ 
label_Copy��5$      $��X2��6,   $
��Left=�69   $��
90,312,0,0q�6T   $	��Top=�6h     5%      -   5        $��y1��5%   %   $
��Left=�6/   $��190,309,0,0q�6J   $	��Top=�6_    6w   �� $ VSlider��$ 
LowerValue�6�   �� 5&      -   5        $ label_Copy1��5&      $��Y1��6-   $
��Left=�6:   $��170,312,0,0q�6U   $	��Top=�6j     5'      -   5        $��y2��5'   %   $
��Left=�6/   $��270,309,0,0q�6J   $	��Top=�6_    6w   �� $ VSlider��$ HigherValue�6�   �� 5(      -   5        $ label_Copy2��5(      $��Y2��6-   $
��Left=�6:   $��250,312,0,0q�6U   $	��Top=�6j   5)      5*      �� 5+   
   -   5        $ gboxLog��5+      $��	Logarithm��6$   $
��Left=�67   $��
412,10,0,0q�6R   $	��Top=�6f   $	��370��6~   $	��129��6�   .��5,      � .+�5-      �� -   5        $ label1��5-      $
��A = ��6(   $
��Left=�67   $��	62,32,0,0q�6R   $	��Top=�6e   $��24(�6}   $  Xceed.Wpf.Toolkit.DoubleUpDown  5.      -   5        $
��logV��5.   $   $
��Left=�60   $��
111,37,0,0q�6K   $	��Top=�6_   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 10X�6�   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   	Increment$ 1X�6�   �� 5/      -   5        $ label1_Copy��5/      $�� * Ln(A + 1) ��6-   $
��Left=�6E   $��
157,32,0,0q�6`   $	��Top=�6t   $��24(�6�   50      51      �� 52   
   -   5        $ gboxExp��52      $��Exponent��6$   $
��Left=�66   $��412,144,0,0q�6Q   $	��Top=�6f   $	��370��6~   $	��129��6�   .��53      � .+�54      �� -   5        $ label1_Copy1��54      $
��A = ��6.   $
��Left=�6=   $��	62,32,0,0q�6X   $	��Top=�6k   $��24(�6�     55      -   5        $
��expV��55   $   $
��Left=�60   $��
111,37,0,0q�6K   $	��Top=�6_   $	 0.1X�6�   $
 0.01X�6�   �� 56      -   5        $ label1_Copy2��56      $��
 * Exp(A) ��6.   $
��Left=�6C   $��
157,32,0,0q�6^   $	��Top=�6r   $��24(�6�   58      59      	� 5:   
   -   5        $ rbtnBal��5:      $�� ��6'   $
��Left=�62   $��386,278,0,0q�6M   $	��Top=�6b   6z   �� 5;   
   -   5        $ groupBox1_Copy1��5;      $��Balance��6,   $
��Left=�6=   $��412,278,0,0q�6X   $	��Top=�6m   $	��370��6�   $��24��6�   �� 5<   
   -   5         ��Name$ btnOK��5<      $��OK��6    $
��Left=�6-   $��627,365,0,0q�6H   $	��Top=�6]   $��75��6u   6�   �� 5=   
   -   5        $ 	btnCancel��5=      $��Cancel��6$   $
��Left=�65   $��707,365,0,0q�6P   $	��Top=�6e   $��75��6}   6�   5?      5@      